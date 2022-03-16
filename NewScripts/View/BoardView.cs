using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class BoardView : MonoBehaviour
{
    public GameObject PanelPrefab;

    [SerializeField] private GameObject parentObject;
    
    private BoardPresenter _boardPresenter;
    
    // Start is called before the first frame update
    void Start()
    {
        _boardPresenter = new BoardPresenter();
        _boardPresenter.panels.ObserveAdd().Subscribe(x =>
        {
            InstatiatePanel(x.Value);
        });

        _boardPresenter.GenerateInput();
    }

    void InstatiatePanel(PanelPresenter objValue)
    {
        Debug.Log("Instantiate");
        var panelObj = Instantiate(PanelPrefab, parentObject.transform, true);
        panelObj.GetComponent<PanelView>().Init(objValue);
    }

    [SerializeField] private Material empty;
    static Material Empty;

    [SerializeField] private Material material1;
    static Material Material1;
    
    [SerializeField] private Material material2;
    static Material Material2;
    
    [SerializeField] private Material material3;
    static Material Material3;
    
    [SerializeField] private Material material4;
    static Material Material4;
    
    [SerializeField] private Material material5;
    static Material Material5;
    
    


    public static Material GetMaterial(int HPValue)
    {
        return HPValue switch
        {
            0 => Empty,
            1 => Material1,
            2 => Material2,
            3 => Material3,
            4 => Material4,
            5 => Material5,
            _ => null
        };
    }

    public static Vector2 GetPanelPosition(int x,int y)
    {
        float xPos = -(Model.Width/2f) + x + 0.5f;
        float yPos = -(Model.Height/2f) + y +0.5f;
        
        return new Vector2(xPos,yPos);
    }
}
