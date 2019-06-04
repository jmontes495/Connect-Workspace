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

    private DraggablePiece hoveOverPiece;

    private CellBehaviour currentCell;

    private bool snapping;

    void Start()
    {
        myTransform = transform;
    }

    private void Update()
    {
        RefreshMousePosition();

        if (hoveOverPiece == null)
        {
            LookForNewObject();
        }

        if (hoveOverPiece != null)
        {
            if (hoveOverPiece.IsDragging)
                currentPiece = hoveOverPiece;
            else
            {
                hoveOverPiece = null;
                currentPiece = null;
            }
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
        if (currentPiece != null)
        {
            currentCell = other.GetComponent<CellBehaviour>();
            currentPiece.ChangeInitialPosition(currentSnapPosition, currentCell.Row, currentCell.Column);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentSnapPosition = myTransform.position;
        currentCell = null;
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
            hoveOverPiece = hit.collider.GetComponent<DraggablePiece>();
        }
    }

    private void DetermineCurrentPieceFate()
    {
        if (currentPiece.IsDragging)
        {
            if (currentPiece.myTransform == null)
            { return; }
            currentPiece.myTransform.position = currentSnapPosition;
        }
        else if (!currentPiece.IsDragging && !snapping)
            currentPiece.CancelSelection();
        else if (!currentPiece.IsDragging && snapping)
        {
            currentPiece.ChangeInitialPosition(currentSnapPosition, currentCell.Row, currentCell.Column);
            currentPiece.CancelSelection();
        }
    }
}
