using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColorizer : MonoBehaviour
{
    private Renderer renderer;

    [SerializeField]
    private Color theColor;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = theColor;
    }

    private void Update()
    {
        if (renderer.material.color != theColor)
        {
            renderer = GetComponent<Renderer>();
            renderer.material.color = theColor;
        }
    }

}
