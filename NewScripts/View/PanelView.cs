using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PanelView : MonoBehaviour
{
   private MeshRenderer _renderer;
   public void Init(PanelPresenter presenter)
   {
      SetMaterial(presenter.Panel.Value.panelHP);
      SetPosition(presenter.Panel.Value.x,presenter.Panel.Value.y);
      presenter.Panel.Subscribe(x => { SetMaterial(x.panelHP); })
         .AddTo(this);
   }


   void SetPosition(int x,int y)
   {
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
