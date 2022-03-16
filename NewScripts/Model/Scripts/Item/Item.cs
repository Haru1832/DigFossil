using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    internal Item(ItemEnum itemEnum,int width,int height)
    {
        ItemEnum=itemEnum;
        Width = width;
        Height = height;
    }

    internal void Init(int x,int y)
    {
        X = x;
        Y = y;
    }

    public ItemEnum ItemEnum;
    public int X;
    public int Y;
    public int Width;
    public int Height;
}
