using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEvaluation : MonoBehaviour
{
    [SerializeField]
    private Button startDayButton;

    [SerializeField]
    private TextMeshProUGUI productivityInfo;

    [SerializeField]
    private TextMeshProUGUI finalResult;

    [SerializeField]
    private float goalProductivity;

    private DraggablePiece[] pieces;

    // Start is called before the first frame update
    void Start()
    {
        ProductivityController.InitialProductivityCalculated += SetInitialProductivity;
        ProductivityController.StartedProductivityCalculation += HideButton;
        ProductivityController.ProductivityDecreased += ReducedProductivity;
        ProductivityController.ProductivityIncreased += IncreasedProductivity;
        ProductivityController.ProductivityIncreased += IncreasedProductivity;
        ProductivityController.FinishedProductivityCalculation += SetFinalResult;
        ProductivityController.RestartedLevel += RestartScreen;
        DraggablePiece.SetPiece += EvaluateButton;

        pieces = Object.FindObjectsOfType<DraggablePiece>();

        productivityInfo.text = "";
        startDayButton.gameObject.SetActive(false);
        finalResult.transform.parent.gameObject.SetActive(false);
    }

    private void EvaluateButton()
    {
        foreach (DraggablePiece piece in pieces)
        {
            if (piece.pieceState == DraggablePiece.PieceState.Invalid)
            {
                startDayButton.gameObject.SetActive(false);
                return;
            }
        }
        
        startDayButton.gameObject.SetActive(true);
    }

    private void HideButton()
    {
        startDayButton.gameObject.SetActive(false);
    }

    private void SetInitialProductivity()
    {
        SetProductivityText("black");
    }

    private void IncreasedProductivity()
    {
        SetProductivityText("green");
    }

    private void ReducedProductivity()
    {
        SetProductivityText("red");
    }

    private void SetProductivityText(string productivityColor)
    {
        productivityInfo.text = "Productivity: <color=" + productivityColor + ">" + ProductivityController.instance.CurrentProductivity +  "/" + ProductivityController.instance.TotalProductivity + "</color><br>" + "Required: " + goalProductivity;
    }

    private void SetFinalResult()
    {
        finalResult.transform.parent.gameObject.SetActive(true);
        if (ProductivityController.instance.CurrentProductivity >= goalProductivity)
        {
            finalResult.text = "DAY COMPLETED PRODUCTIVELY.";
        }
        else
        {
            finalResult.text = "PRODUCTIVITY INSUFFICIENT. <br>PRESS 'N' TO RETRY.";
        }
    }

    private void RestartScreen()
    {
        productivityInfo.text = "";
        startDayButton.gameObject.SetActive(false);
        finalResult.transform.parent.gameObject.SetActive(false);
        SetInitialProductivity();
    }

    private void OnDestroy()
    {
        ProductivityController.InitialProductivityCalculated -= SetInitialProductivity;
        ProductivityController.StartedProductivityCalculation -= HideButton;
        ProductivityController.ProductivityDecreased -= ReducedProductivity;
        ProductivityController.ProductivityIncreased -= IncreasedProductivity;
        ProductivityController.ProductivityIncreased -= IncreasedProductivity;
        ProductivityController.FinishedProductivityCalculation -= SetFinalResult;
        ProductivityController.RestartedLevel -= RestartScreen;
        DraggablePiece.SetPiece -= EvaluateButton;
    }
}
