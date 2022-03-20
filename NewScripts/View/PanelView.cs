using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PanelView : MonoBehaviour
{
   //Raycastで取得した時にx,yを取得できるための変数
   public int x;
   public int y;
   
   private MeshRenderer _renderer;
   
   
   public void Init(Panel panel)
   {
      SetMaterial(panel.panelHP);
      SetPosition(panel.x,panel.y);
   }

   public void UpdateHPView(int HPValue)
   {
      SetMaterial(HPValue);
   }


   void SetPosition(int x,int y)
   {
      this.x = x;
      this.y = y;
      Vector2 panelPosition = BoardView.GetPanelPosition(x, y);
      transform.position = panelPosition;
   }

   void SetMaterial(int HPValue)
   {
      _renderer = GetComponent<MeshRenderer>();
      Material material = BoardView.GetMaterial(HPValue);
      _renderer.material = material;
   }
}
