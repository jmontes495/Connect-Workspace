using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggablePiece : MonoBehaviour
{
    public bool isDragging;

    private Transform myTransform;

    private Vector3 initialPosition;

    private void Start()
    {
        myTransform = transform;
        initialPosition = myTransform.position;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            myTransform.Rotate(new Vector3(0f,0f,90f));
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    public void ChangeInitialPosition(Vector3 newPosition)
    {
        initialPosition = newPosition;
    }

    public void CancelSelection()
    {
        myTransform.position = initialPosition;
    }
}
