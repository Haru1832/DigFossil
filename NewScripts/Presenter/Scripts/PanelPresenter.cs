using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PanelPresenter
{
    public Panel Panel;

    private Subject<Panel> _UpdateHPPanel ;

    private PanelView _panelView;

    public PanelPresenter(Panel panel,PanelView panelView)
    {
        this._panelView = panelView;
        Panel = panel;
        
        _UpdateHPPanel = new Subject<Panel>();
    }

    public void UpdateHP(int HPValue)
    {
        _panelView.UpdateHPView(HPValue);
    }

}
