using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellHighlighter : MonoBehaviour
{

    private Renderer image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Renderer>();
        image.material.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        image.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        image.material.color = Color.yellow;
    }
}
