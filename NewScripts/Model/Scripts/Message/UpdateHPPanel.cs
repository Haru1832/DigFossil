using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHPPanel 
{
    public Panel Panel{get; private set;}

    internal UpdateHPPanel(Panel panel)
    {
        Panel = panel;
    }
}
