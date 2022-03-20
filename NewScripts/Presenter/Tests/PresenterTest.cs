using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class PresenterTest
{
    //テスト用のスクリプト
    
    // A Test behaves as an ordinary method
    [Test]
    public void PresenterTestSimple()
    {
        // Use the Assert class to test conditions
        BoardPresenter boardPresenter = new BoardPresenter();
        
        boardPresenter.GenerateBoard();
        //クリアできるまで掘る
        while (!boardPresenter.IsClear.Value)
        {
            int randomX = Random.Range(0, Model.Width);
            int randomY = Random.Range(0, Model.Height);
            boardPresenter.InputDig(new Vector2Int(randomX,randomY));
        }
        Assert.That(true);
    }

}
