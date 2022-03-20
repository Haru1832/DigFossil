using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;


public class PanelBoard
{
    
    //監視対象の提供
    private Subject<UpdateHPMessage> _updateUIPanel  = new Subject<UpdateHPMessage>();
    private Subject<GeneratePanelMessage> _generatePanel  = new Subject<GeneratePanelMessage>();
    
    private Subject<GenerateItemMessage> _generateItem = new Subject<GenerateItemMessage>();


    public IObservable<UpdateHPMessage> UpdateHPPanel => _updateUIPanel;
    public IObservable<GeneratePanelMessage> GeneratePanel => _generatePanel;
    public IObservable<GenerateItemMessage> GenerateItem => _generateItem;


    ReactiveProperty<bool> isClear;
    public IReadOnlyReactiveProperty<bool> IsClear => isClear;
    
    ReactiveProperty<bool> isGameOver;
    public IReadOnlyReactiveProperty<bool> IsGameOver => isGameOver;
    
    
    
    //盤面のパネル配列を保存
    internal Panel[,] board;
    
    //使用するアイテム
    List<Item> stageItems;

    private int _width;
    private int _height;

    internal PanelBoard(int width, int height,List<Item>stageItems)
    {
        _width = width;
        _height = height;
        this.stageItems = stageItems;

        board = new Panel[width, height];
        isClear = new ReactiveProperty<bool>();
        isGameOver = new ReactiveProperty<bool>();
    }
    

    //パネルの生成
    public void Generate()
    {
        GeneratePanelMessage generatePanelMessage=new GeneratePanelMessage();
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                int randomHP = Random.Range(1, 6);
                var newPanel = new Panel(i, j, randomHP);
                board[i, j] = newPanel;
                generatePanelMessage.AddGeneratePanel(newPanel);
            }
        }
        _generatePanel.OnNext(generatePanelMessage);
        Debug.Log(_generatePanel);
        GenerateItems();
    }

    
    //アイテムの生成
    private void GenerateItems()
    {
        SetItems();

        void SetItems()
        {

            List<Item> currentItems = new List<Item>();

            foreach (Item item in stageItems)
            {
                var canColumns = _width - item.Width;
                var canRows = _height - item.Height;

                var column = Random.Range(0, canColumns);
                var row = Random.Range(0, canRows);
                


                currentItems.Add(item);

                
                //置こうとしているアイテムの周りに既にアイテムがあり重ならないかどうか確かめる
                //置けるまで再起（この部分無限ループになり得るので対策必要）->回数制限をつけ、ダメならアイテム自体を入れ替えるとかが良いか（未実装）
                for (int i = 0; i < item.Width; i++)
                {
                    for (int j = 0; j < item.Height; j++)
                    {
                        var panel = board[column + i, row + j];
                        //アイテムの位置が被った時
                        if (panel.IsUnderItem || panel == null)
                        {
                            
                            //一旦リセットして再起
                            foreach (var _panel in board)
                            {
                                _panel.IsUnderItem = false;
                            }
                            currentItems.Clear();
                            SetItems();
                            return;
                        }
                        else
                        {
                            //置けたということでアイテムがあるフラグを設定
                            panel.IsUnderItem = true;
                        }

                    }
                }
                //for文を抜けられたということはアイテムの座標被りが無かった
                item.X = column;
                item.Y = row;
            }
            
            //アイテムを全て設置完了
            GenerateItemMessage generatePanelMessage=new GenerateItemMessage();
            foreach (var item in currentItems)
            {
                generatePanelMessage.AddGenerateItem(item);    
            }
            
            _generateItem.OnNext(generatePanelMessage);
            
        }
    }
    
    
    //掘る処理（ポジション指定）
    public void Dig(Vector2Int digPosition)
    {
        var panel = board[digPosition.x, digPosition.y];
        
        SubstractHP(panel);
        
        UpdateHPMessage updateHpPanel = new UpdateHPMessage();
        
        updateHpPanel.AddUpdateHPPanel(panel);
        _updateUIPanel.OnNext(updateHpPanel);
        
        Debug.Log(String.Format("[{0},{1}:{2}:{3}]",panel.X,panel.Y,panel.PanelHP,panel.IsUnderItem));



        //HP減算処理
        void SubstractHP(Panel panel)
        {
            panel.PanelHP -= 1;
            if (panel.PanelHP <= 0 && panel.IsUnderItem)
            {
                panel.IsUnderItem = false;
            }
            
            //クリアチェック
            if (CheckGameClear())
            {
                isClear.Value = true;
                Debug.Log("GameClear");
            }
        }
    }


    internal bool CheckGameClear()
    {
        foreach (var panel in board)
        {
            if (panel.IsUnderItem && panel.PanelHP > 0)
                return false;
        }
        
        return true;
    }
}
