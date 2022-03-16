using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    //設定をここに記述（外部のサービスから取得するようにすれば良い？）
    public static readonly int Width = 10;
    public static readonly int Height = 4;
    public static readonly List<Item> Items=new List<Item>()
    {
        new Item(ItemEnum.fossil,2,2)
    };

    static Model()
    {
        Board = new PanelBoard(Width,Height,Items);
    }   
    
    public static PanelBoard Board { get; }

}
