using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggablePiece : MonoBehaviour
{
    public bool isDragging;

	public int blockers;

	private Renderer image;

	public Transform myTransform;

    private Vector3 initialPosition;

    private BaseEmployee employee;

    private void Start()
    {
        employee = GetComponent<BaseEmployee>();
        myTransform = gameObject.transform;
        initialPosition = myTransform.position;
		image = GetComponent<Renderer>();
        image.material.color = Color.white;
    }

    private void Update()
    {
		if (Input.GetKeyUp(KeyCode.R) && isDragging)
        {
            myTransform.Rotate(new Vector3(0f,0f,90f));
            GetComponent<BaseEmployee>().GetPosition().ChangeOrientation();
        }
    }

    private void OnMouseDown()
    {
		isDragging = true;
		EvaluateColor();
    }

    private void OnMouseUp()
    {
        isDragging = false;
		CancelSelection();
		EvaluateColor();
    }

    public void ChangeInitialPosition(Vector3 newPosition, int row, int column)
    {
        initialPosition = newPosition;
        employee.GetPosition().ChangePosition(row, column);
    }

    public void CancelSelection()
    {
        myTransform.position = initialPosition;
    }

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Limit" || other.tag == "Piece")
		blockers = 1;

        EvaluateColor();
	}

	private void OnTriggerExit(Collider other)
    {
		if (other.tag == "Limit" || other.tag == "Piece")
            blockers = 0;

        EvaluateColor();
    }

	private void EvaluateColor()
	{
		if (blockers == 0)
		{
			if(isDragging)
				image.material.color = Color.yellow;
			else
				image.material.color = Color.white;
		}
		else
			image.material.color = Color.red;
			
	}
}
