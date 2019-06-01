using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPosition
{
    private int row;

    private int column;

    public enum FacingOrientation { Left, Down, Right, Up};

    private FacingOrientation facingOrientation;

    public void Initialize(FacingOrientation initialOrientation)
    {
        row = -1;
        column = -1;
        facingOrientation = initialOrientation;
    }

    public void ChangePosition(int newRow, int newColumn)
    {
        row = newRow;
        column = newColumn;
    }

    public int GetRow()
    {
        return row;
    }

    public int GetColumn()
    {
        return column;
    }

    public void ChangeOrientation()
    {
        if (facingOrientation == FacingOrientation.Up)
            facingOrientation = FacingOrientation.Left;
        else if (facingOrientation == FacingOrientation.Left)
            facingOrientation = FacingOrientation.Down;
        else if (facingOrientation == FacingOrientation.Down)
            facingOrientation = FacingOrientation.Right;
        else if (facingOrientation == FacingOrientation.Right)
            facingOrientation = FacingOrientation.Up;
    }

    public FacingOrientation GetOrientation()
    {
        return facingOrientation;
    }
}
