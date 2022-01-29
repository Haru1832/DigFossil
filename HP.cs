using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP
{
    private SubscribeValue<int> hp;

    public HP(int hpValue)
    {
        hp=new SubscribeValue<int>();
        hp.Value = hpValue;
    }

    public void Add(int value)
    {
        hp.Value += value;
    }

    public void Subtract(int value)
    {
        hp.Value -= value;
        hp.Value = hp.Value >= 0 ? hp.Value : 0;
    }
    
    public void Subscribe(Action<int> action)
    {
        hp.Subscribe += action;
    }
    

    public int GetHP()
    {
        return hp.Value;
    }
    
    
}
