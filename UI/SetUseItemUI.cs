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
        game.ObserveEveryValueChanged(x => x.usingItemEnum)
            .Subscribe(SetUI)
            .AddTo(this);
    }

    void SetUI(DigItemEnum itemEnum)
    {
        PickelUI.SetActive(false);
        HammerUI.SetActive(false);
        BombUI.SetActive(false);

        switch (itemEnum)
        {
            case DigItemEnum.Pickel:PickelUI.SetActive(true);
                break;
            case DigItemEnum.Hammer:HammerUI.SetActive(true);
                break;
            case DigItemEnum.Bomb:BombUI.SetActive(true);
                break;
            default: break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
