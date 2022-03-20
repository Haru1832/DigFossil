using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHPMessage 
{
    private List<UpdateHPPanel> updateHPPanels=new List<UpdateHPPanel>();

    internal void AddUpdateHPPanel(Panel panel)
    {
        updateHPPanels.Add(new UpdateHPPanel(panel));
    }
    public IEnumerable<UpdateHPPanel> UpdateHPPanels=>updateHPPanels;
}
