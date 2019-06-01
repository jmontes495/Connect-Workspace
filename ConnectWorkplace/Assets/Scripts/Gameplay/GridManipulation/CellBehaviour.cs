using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour
{
    private int row;
    
    private int column;

    public void SetPosition(int row, int column)
    {
        this.row = row;
        this.column = column;
    }

    public int Row
    {
        get { return row; }
    }

    public int Column
    {
        get { return column; }
    }
}
