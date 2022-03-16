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
        // Use the Assert class to test conditions
        PanelBoard panelBoard = new PanelBoard(6, 7);
        //Debug.Log("a");
        Assert.That(true);
    }


}
