using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePanelMessage
{
    private List<GeneratePanel> generatePanels = new List<GeneratePanel>();

    internal void AddGeneratePanel(Panel panel)
    {
        generatePanels.Add(new GeneratePanel(panel));
    }
    public IEnumerable<GeneratePanel> GeneratePanels=>generatePanels;
}
