using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel
{
    //表示されるパネルの情報

    internal Panel(int x,int y,int panelHP)
    {
        this.X = x;
        this.Y = y;
        this.PanelHP = panelHP;
    }
    
    public int PanelHP;
    public int X;
    public int Y;
    public bool IsUnderItem;
}
