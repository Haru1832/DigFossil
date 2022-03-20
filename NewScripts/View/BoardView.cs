using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class BoardView : MonoBehaviour
{
    [SerializeField]
    private GameObject PanelPrefab;
    [SerializeField]
    private GameObject itemPrefab;

    [SerializeField] 
    private GameObject parentObject;
    
    
    

    [SerializeField] private GameObject parentCanvas;
    
    private Ray rayCamera;
    private Camera mainCamera;
    
    [SerializeField]
    private BoardPresenter _boardPresenter;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera=Camera.main;
        
        //パネルを掘る入力
        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ =>
            {
                if (RayCastToObject<PanelView>(out var _panel))
                {
                    _boardPresenter.InputPanelEvent.OnNext(new Vector2Int(_panel.x,_panel.y));
                }
                
            }).AddTo(this);
    }

    
    //Unity上にパネル生成
    public PanelView InstatiatePanel(Panel panel)
    {
        Debug.Log("InstantiatePanel");
        var panelObj = Instantiate(PanelPrefab, parentObject.transform, true);
        PanelView panelView = panelObj.GetComponent<PanelView>();
        panelView.Init(panel);
        return panelView;
    }

    //Unity上にアイテム生成
    public void InstatiateItem(ItemPresenter itemPresenter)
    {
        Debug.Log("InstantiateItem");
        var itemObj = Instantiate(itemPrefab, parentCanvas.transform);
        itemObj.GetComponent<ItemView>().Init(itemPresenter.X,itemPresenter.Y,itemPresenter.Width,itemPresenter.Height);
    }

    

    //Unity上のアイテムのTransdormを計算
    public static Vector2 GetPanelPosition(int x,int y)
    {
        float xPos = -(Model.Width/2f) + x;
        float yPos = -(Model.Height/2f) + y;
        
        return new Vector2(xPos,yPos);
    }

    //Unity上のパネルのTransformを計算
    public static Vector2 GetItemPosition(int x, int y, int width, int height)
    {
        float xPos = -(Model.Width/2f) + x + (width/2f) ;
        float yPos = -(Model.Height/2f) + y + (height/2f);
        return new Vector2(xPos,yPos);
    }
    
    
    //型指定Raycastでコンポーネント取得まで
    private bool RayCastToObject<T>(out T panelObj)
    {
        panelObj = default;
        rayCamera = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayCamera, out RaycastHit hit))
        {
            if (hit.transform.TryGetComponent<T>(out var obj))
            {
                panelObj = obj;
                return true;
            }
        }
        return false;
    }
    
    
    // //パネルに対するRaycast(上の型指定版を現在使用)
    // private bool RayCastToPanel(out PanelView panelObj)
    // {
    //     panelObj = null;
    //     rayCamera = mainCamera.ScreenPointToRay(Input.mousePosition);
    //     if (Physics.Raycast(rayCamera, out RaycastHit hit))
    //     {
    //         if (hit.transform.TryGetComponent<PanelView>(out var obj))
    //         {
    //             panelObj = obj;
    //             return true;
    //         }
    //     }
    //     return false;
    // }
}
