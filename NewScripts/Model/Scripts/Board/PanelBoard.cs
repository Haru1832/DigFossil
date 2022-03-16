using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBoard
{
    internal Panel[,] board { get; set; }
    
    private int _width;
    private int _height;
    
    internal PanelBoard(int width,int height)
    {
        _width = width;
        _height = height;
        
        board =new Panel[width,height];
    }
}
