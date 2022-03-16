using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PanelPresenter
{
    public ReactiveProperty<Panel> Panel;

    public int x;
    public int y;
    
    private Subject<Panel> _UpdateHPPanel ;
    internal IObserver<Panel> UpdateHPObserver=>_UpdateHPPanel;
    public IObservable<Panel> UpdateHPObservable => _UpdateHPPanel;
    


    public PanelPresenter(Panel panel)
    {
        _UpdateHPPanel = new Subject<Panel>();
        Panel = new ReactiveProperty<Panel>();
        Panel.Value = panel;
        UpdateHPObservable.Subscribe(x => { Panel.Value = x; });
    }
    
    
}
