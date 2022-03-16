using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PanelBoardTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void PanelBoardTestSimplePasses()
    {
        int width = 6;
        int height = 7;
        // Use the Assert class to test conditions
        PanelBoard panelBoard = new PanelBoard(width, height,new List<Item>()
        {
            new Item(ItemEnum.fossil,2,2)
        });
        panelBoard.Generate();
        //Debug.Log("a");

        while (!panelBoard.CheckGameClear())
        {
            int randomX = Random.Range(0, width);
            int randomY = Random.Range(0, height);
            panelBoard.Dig(new Vector2Int(randomX,randomY));
        }
        Assert.That(true);

       
    }


}
