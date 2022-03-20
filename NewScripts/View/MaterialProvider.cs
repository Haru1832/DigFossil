using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialProvider : MonoBehaviour
{
    //インスペクターから参照したMaterialをstatic関数から扱うため、static変数を用意
    [SerializeField] private Material empty;
    static Material Empty;

    [SerializeField] private Material material1;
    static Material Material1;
    
    [SerializeField] private Material material2;
    static Material Material2;
    
    [SerializeField] private Material material3;
    static Material Material3;
    
    [SerializeField] private Material material4;
    static Material Material4;
    
    [SerializeField] private Material material5;
    static Material Material5;
    
    // Start is called before the first frame update
    void Start()
    {
        Empty = empty;
        Material1 = material1;
        Material2 = material2;
        Material3 = material3;
        Material4 = material4;
        Material5 = material5;
    }
    
    public static Material GetMaterial(int HPValue)
    {
        return HPValue switch
        {
            0 => Empty,
            1 => Material1,
            2 => Material2,
            3 => Material3,
            4 => Material4,
            5 => Material5,
            _ => Empty
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
