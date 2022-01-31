using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SetUseItemUI : MonoBehaviour
{
    [SerializeField] private Game game;

    [SerializeField] private GameObject PickelUI;
    [SerializeField] private GameObject HammerUI;
    [SerializeField] private GameObject BombUI;
    
    // Start is called before the first frame update
    void Start()
    {
        game.ObserveEveryValueChanged(x => x.usingItem)
            .Subscribe(SetUI)
            .AddTo(this);
    }

    void SetUI(DigItem.DigItems item)
    {
        PickelUI.SetActive(false);
        HammerUI.SetActive(false);
        BombUI.SetActive(false);

        switch (item)
        {
            case DigItem.DigItems.Pickel:PickelUI.SetActive(true);
                break;
            case DigItem.DigItems.Hammer:HammerUI.SetActive(true);
                break;
            case DigItem.DigItems.Bomb:BombUI.SetActive(true);
                break;
            default: break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
