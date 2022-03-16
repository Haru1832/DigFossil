using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuleUI : MonoBehaviour
{
    [SerializeField]
    private bool isInGame;

    [SerializeField] private Game game;
    
    private Button _button;
    private int index = 0;
    [SerializeField] private GameObject[] ruleUIs;
    private bool isRuleOpen;

    // Start is called before the first frame update
    void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetActiveUIs);
    }



    // Update is called once per frame
    void Update()
    {
        if (!isRuleOpen) return;
        if (!Input.GetMouseButtonDown(0)) return;
        
        if (index >= ruleUIs.Length)
        {
            CloseRuleUI();
            return;
        }
        
        OpenNextUI(index);
    }
    
    void SetActiveUIs()
    {
        if (index != 0)
        {
            CloseRuleUI();
            return;
        }

        OpenNextUI(index);
        isRuleOpen = true;
        if (isInGame)
            game.IsGameStoped = true;
    }

    private void SetFalseAllUIs()
    {
        foreach (var UI in ruleUIs)
        {
            UI.SetActive(false);
        }
    }

    private void CloseRuleUI()
    {
        SetFalseAllUIs();
        index = 0;
        isRuleOpen = false;
        if (isInGame)
            game.IsGameStoped = false;
    }

    private void OpenNextUI(int indexValue)
    {
        SetFalseAllUIs();
        ruleUIs[indexValue].SetActive(true);
        index++;
    }
}
