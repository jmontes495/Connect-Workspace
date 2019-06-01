using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPositionSetter : MonoBehaviour
{
    [SerializeField]
    private int Rows;

    [SerializeField]
    private int Columns;

    private CellBehaviour[] cells;
    void Start()
    {
        cells = GetComponentsInChildren<CellBehaviour>();

        int currentCell = 0;
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                cells[currentCell].SetPosition(i, j);
                currentCell++;
            }
        }
    }
    
}
