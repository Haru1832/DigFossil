using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstTextUI : MonoBehaviour
{
    [SerializeField] private Game game;
    [SerializeField] private Board board;
    [SerializeField] private GameObject deleteObj;

    private Text _text;
    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = board.itemsLength + "個埋まっているようだ！";
        game.IsGameStoped = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            deleteObj.SetActive(false);
            game.IsGameStoped = false;
        }
    }
}
