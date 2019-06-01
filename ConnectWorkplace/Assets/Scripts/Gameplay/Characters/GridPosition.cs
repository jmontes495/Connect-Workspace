using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPosition
{
    private int row;

    private int column;

    private int orientation;

    public enum FacingOrientation { Left, Down, Right, Up};

    private FacingOrientation facingOrientation;

    public void Initialize(FacingOrientation initialOrientation)
    {
        row = -1;
        column = -1;
        facingOrientation = initialOrientation;

        if (facingOrientation == FacingOrientation.Down)
                orientation = 0;
        if (facingOrientation == FacingOrientation.Right)
            orientation = 90;
        if (facingOrientation == FacingOrientation.Up)
            orientation = 180;
        else
            orientation = 270;
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

    public void ChangeOrientation(int newOrientation)
    {
        orientation = newOrientation;

        if (orientation%360 == 0)
            facingOrientation = FacingOrientation.Down;
        else if (orientation%360 == 90)
            facingOrientation = FacingOrientation.Right;
        else if (orientation%360 == 180)
            facingOrientation = FacingOrientation.Up;
        else
            facingOrientation = FacingOrientation.Left;
    }

    public FacingOrientation GetOrientation()
    {
        return facingOrientation;
    }
}
