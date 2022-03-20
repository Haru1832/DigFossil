using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

public class BoardPresenter
{
    public ReactiveCollection<PanelPresenter> panels { get; private set; }
    public ReactiveCollection<ItemPresenter> items { get; private set; }


    private Subject<Vector2Int> inputPanelEvent;
    public IObserver<Vector2Int> InputPanelEvent=>inputPanelEvent;

    private ReactiveProperty<bool> isClear;
    public IReadOnlyReactiveProperty<bool> IsClear => isClear;
    
    private ReactiveProperty<bool> isGameOver;
    public IReadOnlyReactiveProperty<bool> IsGameOver => isGameOver;

    public BoardPresenter()
    {
        isGameOver=new ReactiveProperty<bool>();
        isClear = new ReactiveProperty<bool>();
        panels = new ReactiveCollection<PanelPresenter>();
        items=  new ReactiveCollection<ItemPresenter>();
        inputPanelEvent=new Subject<Vector2Int>();
        inputPanelEvent.Subscribe(Model.Board.Dig);
        
        SubscribeModel();
    }


    void SubscribeModel()
    {
        Model.Board.GeneratePanel.Subscribe(GeneratePanel);
        Model.Board.GenerateItem.Subscribe(GenerateItem);
        Model.Board.UpdateHPPanel.Subscribe(UpdateHPPanel);

        Model.Board.IsClear.Where(x => x).Subscribe(_ => isClear.Value = true);
        Model.Board.IsGameOver.Where(x => x).Subscribe(_ => isGameOver.Value = true);
    }


    void GeneratePanel(GeneratePanelMessage message)
    {
        foreach (var generatePanel in message.GeneratePanels)
        {
            var panel = new PanelPresenter(generatePanel.Panel);
            panels.Add(panel);
            Debug.Log("GeneratePanel");
        }
    }

    void GenerateItem(GenerateItemMessage message)
    {
        foreach (var generateItem in message.GenerateItems)
        {
            var item = new ItemPresenter(generateItem.Item);
            items.Add(item);
            Debug.Log("GenerateItem");
        }
    }
    
    
    void UpdateHPPanel(UpdateHPMessage message)
    {
        foreach (var updateHpPanel in message.UpdateHPPanels)
        {
            Panel _panel = new Panel();

            PanelPresenter _panelPresenter = default;

            foreach (var panel in panels)
            {
                if ((panel.Panel.Value.x == updateHpPanel.Panel.x) && (panel.Panel.Value.y == updateHpPanel.Panel.y))
                {
                    _panelPresenter = panel;
                }
            }
            

            var targetPanel = _panelPresenter;
            targetPanel.UpdateHPObserver.OnNext(targetPanel.Panel.Value);
        }
    }
    
    
    
    //Viewからボード生成
    public void GenerateBoard()
    {
        Model.Board.Generate();
    }
    
    
    //テスト用にInternalで関数
    internal void InputDig(Vector2Int vec)
    {
        InputPanelEvent.OnNext(vec);
    }
    
}
