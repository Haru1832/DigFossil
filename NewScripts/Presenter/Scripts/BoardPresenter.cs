using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

public class BoardPresenter : MonoBehaviour
{
    [SerializeField] private BoardView boardView;

    public List<PanelPresenter> panels;
    public List<ItemPresenter> items;
    private Subject<Vector2Int> _inputPanelEvent;
    public IObserver<Vector2Int> InputPanelEvent=>_inputPanelEvent;
    


    private void Start()
    {
        panels = new List<PanelPresenter>();
        items=  new List<ItemPresenter>();
        _inputPanelEvent=new Subject<Vector2Int>();
        _inputPanelEvent.Subscribe(Model.Board.Dig);
        
        
        SubscribeModel();
        
        GenerateBoard();
    }

    void SubscribeModel()
    {
        Model.Board.GeneratePanel.Subscribe(GeneratePanel);
        Model.Board.GenerateItem.Subscribe(GenerateItem);
        Model.Board.UpdateHPPanel.Subscribe(UpdateHPPanel);

        Model.Board.IsClear.Where(x => x).Subscribe(_ => PresentClear());
        Model.Board.IsGameOver.Where(x => x).Subscribe(_ => PresentGameOver());
    }


    void GeneratePanel(GeneratePanelMessage message)
    {
        foreach (var generatePanel in message.GeneratePanels)
        {
            
            PanelView  panelView= boardView.InstatiatePanel(generatePanel.Panel);
            
            var panel = new PanelPresenter(generatePanel.Panel,panelView);
            panels.Add(panel);
            Debug.Log("GeneratePanel");
        }
    }

    void GenerateItem(GenerateItemMessage message)
    {
        foreach (var generateItem in message.GenerateItems)
        {
            var item = new ItemPresenter(generateItem.Item);
            boardView.InstatiateItem(item);
            items.Add(item);
            Debug.Log("GenerateItem");
        }
    }
    
    
    void UpdateHPPanel(UpdateHPMessage message)
    {
        foreach (var updateHpPanel in message.UpdateHPPanels)
        {
            PanelPresenter _panelPresenter = default;

            foreach (var panel in panels)
            {
                if ((panel.Panel.x == updateHpPanel.Panel.x) && (panel.Panel.y == updateHpPanel.Panel.y))
                {
                    panel.UpdateHP(panel.Panel.panelHP);
                }
            }
        }
    }

    void PresentClear()
    {
        //Viewのクリア処理
    }

    void PresentGameOver()
    {
        //Vieｗのゲームオーバー処理
    }

    
    public void GenerateBoard()
    {
        Model.Board.Generate();
    }
    
    
}
