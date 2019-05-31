using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPieceSnapper : MonoBehaviour
{
    private Transform myTransform;

    [SerializeField]
    private Vector3 currentSnapPosition;

    Ray ray;
    RaycastHit hit;

    [SerializeField]
    private DraggablePiece currentObject;

    private bool snapping;

    void Start()
    {
        myTransform = transform;
    }

    private void Update()
    {
        Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseposition.z = 0;
        myTransform.position = mouseposition;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            currentObject = hit.collider.GetComponent<DraggablePiece>();
        }

        if(!snapping)
            currentSnapPosition = myTransform.position;

        if (currentObject != null && currentObject.isDragging)
            currentObject.transform.position = currentSnapPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentSnapPosition = other.gameObject.transform.position;
        currentSnapPosition.z = 0;
        snapping = true;
    }

    private void OnTriggerExit(Collider other)
    {
        currentSnapPosition = myTransform.position;
        snapping = false;
    }
}
