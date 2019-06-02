using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticGridPosition : MonoBehaviour
{
    [SerializeField]
    private int row;

    [SerializeField]
    private int column;

    public void SetStaticPosition()
    {
        GetComponent<BaseEmployee>().GetPosition().ChangePosition(row, column);
    }

}
