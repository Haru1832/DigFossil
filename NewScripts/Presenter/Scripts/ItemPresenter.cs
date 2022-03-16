using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPresenter
{
    public int X;
    public int Y;
    public int Width;
    public int Height;
    
    public ItemPresenter(Item item)
    {
        X = item.X;
        Y = item.Y;
        Width = item.Width;
        Height = item.Height;
    }
}
