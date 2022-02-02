using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private GameObject PickelEffect;
    [SerializeField] private GameObject HammerEffect;
    [SerializeField] private GameObject BombEffect;
    
    private Vector3 add_y=new Vector3(0,10,0);
    // Start is called before the first frame update

    public void InstantiateEffect(DigItemEnum digItemEnum,Transform panelTransform)
    {
        switch (digItemEnum)
        {
            case DigItemEnum.Pickel: Instantiate(PickelEffect,panelTransform.position+add_y,Quaternion.identity);
                break;
            case DigItemEnum.Hammer: Instantiate(HammerEffect,panelTransform.position+add_y,Quaternion.identity);
                break;
            case DigItemEnum.Bomb: Instantiate(BombEffect,panelTransform.position+add_y,Quaternion.identity);
                break;    
            default: break;
        }
    }
    
}
