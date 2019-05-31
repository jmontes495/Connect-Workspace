using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggablePiece : MonoBehaviour
{
    public bool isDragging;

    public bool isSnapping;

    private Transform myTransform;

    private void Start()
    {
        myTransform = transform;
    } 

    private void OnMouseDown()
    {
        Debug.LogError("Entra");

        isDragging = true;
    }

    private void OnMouseUp()
    {
        Debug.LogError("Sale");

        isDragging = false;
    }    
}
