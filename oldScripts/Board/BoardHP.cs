using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHP : MonoBehaviour
{
    [SerializeField]
    private int boardHP;

    public int BoardHp
    {
        get => boardHP;
        set => boardHP = value;
    }

    public void Subtract(int value)
    {
        if(boardHP-value>=0) 
            boardHP -= value;
        else
        {
            boardHP = 0;
        }
    }
}
