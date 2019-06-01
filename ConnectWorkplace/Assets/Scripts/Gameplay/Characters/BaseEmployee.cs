using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GridPosition;

public class BaseEmployee : MonoBehaviour
{
    private float productivity; //Value between 1 and 100

    [SerializeField]
    private List<PersonalTrait> traits;

    private GridPosition currentPosition;

    [SerializeField]
    private FacingOrientation initialFacing;

    private void Start()
    {
        currentPosition = new GridPosition();
        currentPosition.Initialize(initialFacing);
    }

    public bool ContainsTrait(PersonalTrait theTrait)
    {
        return traits.Contains(theTrait);
    }

    public void ReduceProductivity(float productivityLost)
    {
        productivity -= productivityLost;
    }

    public GridPosition GetPosition()
    {
        return currentPosition;
    }
}
