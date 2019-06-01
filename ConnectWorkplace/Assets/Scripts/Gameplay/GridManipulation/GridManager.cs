using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private int maxRow;

    [SerializeField]
    private int maxColumn;

    public static GridManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public int MaxRow
    {
        get { return maxRow; }
    }

    public int MaxColumn
    {
        get { return maxColumn; }
    }
}
