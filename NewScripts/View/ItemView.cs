using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemView:MonoBehaviour
{
    public void Init(int x,int y,int width,int height)
    {
        SetPosition(x,y,width,height);
        
    }

    void SetPosition(int x,int y,int width,int height)
    {
        var vec = BoardView.GetItemPosition(x, y, width, height);
        
        transform.position = new Vector3(vec.x,vec.y,1);
    }
    
}
