using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateItemMessage
{
    private List<GenerateItem> generateItems{get;}=new List<GenerateItem>();

    internal void AddGenerateItem(Item item)
    {
        generateItems.Add(new GenerateItem(item));
    }
    public IEnumerable<GenerateItem> GenerateItems=>generateItems;
}
