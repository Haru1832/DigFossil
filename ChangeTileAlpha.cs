using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTileAlpha : MonoBehaviour
{
    private Color _color;
    private float speed=10;

    private MeshRenderer _meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private float alpha_Sin(float time) => Mathf.Sin(time) / 2 + 0.5f;
    
    public IEnumerator ColorCoroutine()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            var material = _meshRenderer.material;
            _color = material.color;
            _color.a = alpha_Sin(Time.time*speed);

            material.color = _color;
        }
    }
}
