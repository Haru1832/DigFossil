using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigItem 
{
    

    public ItemInfo GetItemInfo(DigItemEnum itemEnum)
    {
        switch (itemEnum)
        {
            case DigItemEnum.Pickel: return ItemInfos[(int) DigItemEnum.Pickel];
            case DigItemEnum.Hammer: return ItemInfos[(int) DigItemEnum.Hammer];
            case DigItemEnum.Bomb: return ItemInfos[(int) DigItemEnum.Bomb];
            
            default: return ItemInfos[(int) DigItemEnum.Pickel];
        }
    }

    //public DigItems digItems=DigItems.Pickel;
    
    ItemInfo[] ItemInfos = new ItemInfo[]
    {
        new ItemInfo(DigItemEnum.Pickel,PickelInfo),
        new ItemInfo(DigItemEnum.Hammer,HammerInfo),
        new ItemInfo(DigItemEnum.Bomb,BombInfo), 
    };

    static Vector3[] PickelInfo = new Vector3[]
    {
        new Vector3(-1,0,1),
        new Vector3(0,0,2), 
        new Vector3(0,1,1), 
        new Vector3(0,-1,1), 
        new Vector3(1,0,1),
    };
    
    static Vector3[] HammerInfo = new Vector3[]
    {
        new Vector3(-1,1,1),new Vector3(0,1,2),new Vector3(1,1,1),
        new Vector3(-1,0,2), new Vector3(0,0,2),new Vector3(1,0,2),
        new Vector3(-1,-1,1), new Vector3(0,-1,2),new Vector3(1,-1,1)
    };
    
    static Vector3[] BombInfo = new Vector3[]
    {
        new Vector3(-1,1,1),new Vector3(1,1,1),
        new Vector3(0,0,3),
        new Vector3(-1,-1,1), new Vector3(1,-1,1)
    };
    

    public struct ItemInfo
    {
        public DigItemEnum DigItemEnum;
        public List<int> x;
        public List<int> y;
        public List<int> value;
        public int Length;

        public ItemInfo(DigItemEnum itemEnum,Vector3[] infos)
        {
            DigItemEnum = itemEnum;
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
