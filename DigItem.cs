using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigItem 
{
    public enum DigItems
    {
        Pickel,
        Hummmer
    }

    public ItemInfo GetItemInfo(DigItems item)
    {
        switch (item)
        {
            case DigItems.Pickel: return ItemInfos[(int) DigItems.Pickel];
            case DigItems.Hummmer: return ItemInfos[(int) DigItems.Hummmer];
            
            default: return ItemInfos[(int) DigItems.Pickel];
        }
    }

    public DigItems digItems=DigItems.Pickel;
    
    ItemInfo[] ItemInfos = new ItemInfo[]
    {
        new ItemInfo(DigItems.Pickel,PickelInfo) 
    };

    static Vector3[] PickelInfo = new Vector3[]
    {
        new Vector3(-1,0,1),
        new Vector3(0,0,2), 
        new Vector3(0,1,1), 
        new Vector3(0,-1,1), 
        new Vector3(1,0,1),
    };
    
    // static Vector3[] PickelInfo = new Vector3[]
    // {
    //     new Vector3(-1,0,1),
    //     new Vector3(0,0,2), 
    //     new Vector3(0,1,1), 
    //     new Vector3(0,-1,1), 
    //     new Vector3(1,0,1),
    // };
    
    public struct ItemInfo
    {
        public DigItems DigItem;
        public List<int> x;
        public List<int> y;
        public List<int> value;
        public int Length;

        public ItemInfo(DigItems item,Vector3[] infos)
        {
            DigItem = item;
            x=new List<int>();
            y=new List<int>();
            value=new List<int>();
            Length = infos.Length;

            foreach (var info in infos)
            {
                x.Add((int)info.x);
                y.Add((int)info.y);
                value.Add((int)info.z);
            }
        }
    }

}
