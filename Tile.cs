using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int Column { get { return m_Column; } }
    public int Row { get { return m_Row; } }
    public HP HP { get { return m_HP; } }
    public bool isUnderItem;

    [SerializeField] private GameObject[] tiles;

    [SerializeField] private GameObject chooseTile;

    private ChangeTileAlpha _changeTile;

    //[SerializeField]
    private int m_Column;
    //[SerializeField]
    private int m_Row;

    private HP m_HP;

    private Game m_Game;

    private void Start()
    {
        _changeTile = chooseTile.GetComponent<ChangeTileAlpha>();
    }

    private void OnMouseDown()
    {
        if (m_Game.IsFinished) return;
        Debug.Log(m_Column+":"+m_Row+":item="+isUnderItem);
        m_Game.Dig(this);
    }

    private void OnMouseOver()
    {
        // Debug.Log("MouseOver");
        chooseTile.SetActive(true);
        StartCoroutine(_changeTile.ColorCoroutine());
    }
    
    private void OnMouseExit()
    {
        chooseTile.SetActive(false);
        StopCoroutine(_changeTile.ColorCoroutine());
    }

    public void Initialize(int columnIndex, int rowIndex,int HPIndex,Game game)
    {
        m_Column = columnIndex;
        m_Row = rowIndex;
        m_HP = new HP(HPIndex);
        m_HP.Subscribe(UpdateTile);
        m_Game = game;
        
        UpdateTile(HP.GetHP());
    }

    private void UpdateTile(int value)
    {
        value = value >= 0 ? value : 0;
        GameObject targetTile = GetNumberTile(value);
        
        foreach (var tile in tiles)
        {
            tile.SetActive(false);
        }
        targetTile.SetActive(true);
    }

    private GameObject GetNumberTile(int value)
    {
        return tiles[value];
    }

}
