using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject finishText;
    
    [SerializeField]
    private Board board;
    
    DigItem _digItem = new DigItem();

    public bool IsFinished { get; private set; } = false;
    
    public DigItem.DigItems usingItem = DigItem.DigItems.Pickel;

    public void Dig(Tile tile)
    {
        Tile[,] tiles = board.boardTileArray2d;
        DigItem.ItemInfo itemInfo = _digItem.GetItemInfo(usingItem);
        for (int i = 0; i < itemInfo.Length; i++)
        {
            bool limitColumn = tile.Column + itemInfo.x[i] >= board.Columns || tile.Column + itemInfo.x[i] < 0;
            bool limitRow = tile.Row + itemInfo.y[i] >= board.Rows || tile.Row + itemInfo.y[i] < 0;
            if( limitColumn || limitRow)
                continue;
            
            var targetTile = tiles[tile.Column + itemInfo.x[i], tile.Row + itemInfo.y[i]];
                targetTile.HP.Subtract(itemInfo.value[i]);

        }

        if (CheckGameEnd())
        {
            finishText.SetActive(true);
            IsFinished = true;
        }
    }

    private bool CheckGameEnd()
    {
        Tile[,] tiles = board.boardTileArray2d;
        foreach (var tile in tiles)
        {
            if (tile.isUnderItem && tile.HP.GetHP() > 0)
                return false;
        }

        return true;
    }
    
    
    
}
