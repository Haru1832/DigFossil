using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PanelView : MonoBehaviour
{
   //Raycastで取得した時にx,yを取得できるための変数
   public int X;
   public int Y;
   
   private MeshRenderer _renderer;
   
   
   public void Init(Panel panel)
   {
      SetMaterial(panel.PanelHP);
      SetPosition(panel.X,panel.Y);
   }

   public void UpdateHPView(int HPValue)
   {
      SetMaterial(HPValue);
   }


   void SetPosition(int x,int y)
   {
      X = x;
      Y = y;
      Vector2 panelPosition = BoardView.GetPanelPosition(x, y);
      transform.position = panelPosition;
   }

   void SetMaterial(int HPValue)
   {
      _renderer = GetComponent<MeshRenderer>();
      Material material = MaterialProvider.GetMaterial(HPValue);
      _renderer.material = material;
   }
}
