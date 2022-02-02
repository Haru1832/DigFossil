using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip PickelSE;
    [SerializeField] private AudioClip HammerSE;
    [SerializeField] private AudioClip BombSE;
    
    private Vector3 add_y=new Vector3(0,10,0);
    // Start is called before the first frame update

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySE(DigItemEnum digItemEnum)
    {
        switch (digItemEnum)
        {
            case DigItemEnum.Pickel: _audioSource.PlayOneShot(PickelSE);
                break;
            case DigItemEnum.Hammer: _audioSource.PlayOneShot(HammerSE);
                break;
            case DigItemEnum.Bomb: _audioSource.PlayOneShot(BombSE);
                break;    
            default: break;
        }
    }
}
