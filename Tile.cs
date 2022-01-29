using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int Column { get { return m_Column; } }
    public int Row { get { return m_Row; } }
    public int HP { get { return m_HP; } }
    public bool isChecked;

    [SerializeField] private GameObject[] tiles;

    [SerializeField] private GameObject chooseTile;

    private ChangeTileAlpha _changeTile;

    //[SerializeField]
    private int m_Column;
    //[SerializeField]
    private int m_Row;

    private int m_HP;

    private void Start()
    {
        _changeTile = chooseTile.GetComponent<ChangeTileAlpha>();
    }

    private void OnMouseDown()
    {
        Debug.Log(m_Column+":"+m_Row);
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

    public void Initialize(int columnIndex, int rowIndex,int HPIndex)
    {
        m_Column = columnIndex;
        m_Row = rowIndex;
        m_HP = HPIndex;

        
        UpdateTile();
    }

    private void UpdateTile()
    {
        GameObject targetTile = GetNumberTile();
        foreach (var tile in tiles)
        {
            tile.SetActive(false);
        }
        targetTile.SetActive(true);
    }

    private GameObject GetNumberTile()
    {
        return tiles[HP];
    }

}
