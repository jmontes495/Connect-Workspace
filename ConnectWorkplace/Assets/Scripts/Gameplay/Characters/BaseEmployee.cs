using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GridPosition;

public class BaseEmployee : MonoBehaviour
{
    [SerializeField]
    private Color idColor;
    
    private float productivity; //Value between 1 and 5

    private GridPosition currentPosition;

    [SerializeField]
    private FacingOrientation initialFacing;

    private void Start()
    {
        productivity = 10;
        currentPosition = new GridPosition();
        currentPosition.Initialize(initialFacing);
        if (GetComponent<StaticGridPosition>() != null)
            GetComponent<StaticGridPosition>().SetStaticPosition();

        GetComponent<DraggablePiece>().SetColor(idColor);

        ProductivityController.RestartedLevel += RestartEmployee;
    }

    public void ReduceProductivity(float productivityLost)
    {
        productivity -= productivityLost;
    }

    public void IncreaseProductivity(float productivityGain)
    {
        productivity += productivityGain;
    }

    public GridPosition GetPosition()
    {
        return currentPosition;
    }

    public Color GetColor()
    {
        return idColor;
    }

    public float GetProductivity()
    {
        return productivity;
    }

    private void RestartEmployee()
    {
        productivity = 10;
        currentPosition = new GridPosition();
		currentPosition.Initialize(initialFacing);
        if (GetComponent<StaticGridPosition>() != null)
            GetComponent<StaticGridPosition>().SetStaticPosition();
    }

    private void OnDestroy()
    {
        ProductivityController.RestartedLevel -= RestartEmployee;
    }
}
