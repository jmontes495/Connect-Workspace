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
    private DraggablePiece currentPiece;

    private bool snapping;

    void Start()
    {
        myTransform = transform;
    }

    private void Update()
    {
        RefreshMousePosition();

        if (currentPiece == null || !currentPiece.isDragging)
        {
            LookForNewObject();
        }

        if(!snapping)
            currentSnapPosition = myTransform.position;

        if(currentPiece != null)
            DetermineCurrentPieceFate();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentSnapPosition = other.gameObject.transform.position;
        currentSnapPosition.z = -5;
        snapping = true;
    }

    private void OnTriggerExit(Collider other)
    {
        currentSnapPosition = myTransform.position;
        snapping = false;
    }

    private void RefreshMousePosition()
    {
        Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseposition.z = 0;
        myTransform.position = mouseposition;
    }

    private void LookForNewObject()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            currentPiece = hit.collider.GetComponent<DraggablePiece>();
        }
    }

    private void DetermineCurrentPieceFate()
    {
        if (currentPiece.isDragging)
            currentPiece.transform.position = currentSnapPosition;
        else if (!currentPiece.isDragging && !snapping)
            currentPiece.CancelSelection();
        else if (!currentPiece.isDragging && snapping)
        {
            currentPiece.ChangeInitialPosition(currentSnapPosition);
            currentPiece.CancelSelection();
        }
    }
}
