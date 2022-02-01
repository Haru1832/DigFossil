using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private float defaultduration= 0.2f;
    private float defaultstrength= 0.3f;
    private float ShakePower = 0.5f;

    private float ShakeTime = 0.2f;
    // private int vibrato = 10;
    // private float randomness = 90f;
    // private bool snapping = false;
    // private bool fadeOut = true;

    private Transform defaultPosition;
    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = transform;
    }

    public void Shake(float duration,float strength)
    {
        transform.DOShakePosition(defaultduration+duration*ShakeTime, defaultstrength + strength*ShakePower);
    }
}
