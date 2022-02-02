using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SetUseItem : MonoBehaviour
{
    [SerializeField] private DigItemEnum itemEnum;
    
    [SerializeField] private Game game;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponentInChildren<Button>();
        button.OnClickAsObservable()
            .Subscribe(_ => game.usingItemEnum = itemEnum)
            .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
