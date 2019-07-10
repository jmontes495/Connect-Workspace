using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityController : MonoBehaviour
{
    public delegate void ProductivityEvents();
    public static event ProductivityEvents InitialProductivityCalculated;
    public static event ProductivityEvents StartedProductivityCalculation;
    public static event ProductivityEvents ProductivityIncreased;
    public static event ProductivityEvents ProductivityDecreased;
    public static event ProductivityEvents FinishedProductivityCalculation;
    public static event ProductivityEvents RestartedLevel;

    private BaseEmployee[] employees;

    private bool productivityHasBeenCalculated;

    private List<EmployeeReaction> reactionsPending;

    private ReactionBubble reactionBubble;

    public static ProductivityController instance = null;
    
    private float currentProductivity;
    private float totalProductivity;
    private bool canEvaluate;
    private bool finishedEvaluating;

    public float CurrentProductivity
    {
        get { return currentProductivity; }
    }

    public float TotalProductivity
    {
        get { return totalProductivity; }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(WaitForStart());
    }

    private IEnumerator WaitForStart()
    {
        yield return new WaitForEndOfFrame();
        employees = GetComponentsInChildren<BaseEmployee>();
        reactionsPending = new List<EmployeeReaction>();
        reactionBubble = GetComponentInChildren<ReactionBubble>();
        HideReaction();
        CalculateProductivity();
        canEvaluate = false;
        productivityHasBeenCalculated = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !productivityHasBeenCalculated)
        {
            CalculateCanEvaluate();
            if (canEvaluate)
            {
                CalculateReactions();
                productivityHasBeenCalculated = true;
                StartCoroutine(ShowReactions());
            }
        }

        if (Input.GetKeyUp(KeyCode.N))
        {
            RestartedLevel();
            RestartValues();
        }
    }

    private void RestartValues()
    {
        productivityHasBeenCalculated = false;
        finishedEvaluating = false;
        canEvaluate = false;
		employees = GetComponentsInChildren<BaseEmployee>();
        CalculateProductivity();
    }
    
    private void CalculateCanEvaluate()
    {
        canEvaluate = false;
        foreach (BaseEmployee employee in employees)
        {
            if (employee.GetPosition().GetRow() == -1 || (employee.GetComponent<DraggablePiece>() != null && employee.GetComponent<DraggablePiece>().pieceState == DraggablePiece.PieceState.Invalid))
                return;
        }
        canEvaluate = true;
    }

    private void CalculateProductivity()
    {
        currentProductivity = 0;
        foreach (BaseEmployee employee in employees)
        {
            currentProductivity += employee.GetProductivity();
        }
        totalProductivity = currentProductivity;
        InitialProductivityCalculated();
    }

    private void CalculateReactions()
    {
        foreach (BaseEmployee currentEmployee in employees)
        {
            EvaluateEmployee(currentEmployee);
        }
    }

    private void EvaluateEmployee(BaseEmployee theEmployee)
    {
        PersonalTrait[] employeeTraits = theEmployee.GetComponents<PersonalTrait>();
        foreach (PersonalTrait trait in employeeTraits)
        {
            foreach (BaseEmployee currentEmployee in employees)
            {
                AffectEmployeeWithTrait(currentEmployee, trait);
            }
        }
    }

    private void AffectEmployeeWithTrait(BaseEmployee theEmployee, PersonalTrait theTrait)
    {
        PersonalTrait[] employeeTraits = theEmployee.GetComponents<PersonalTrait>();
        foreach (PersonalTrait trait in employeeTraits)
        {
            EmployeeReaction reaction = theTrait.AffectOther(trait, trait.GetPosition());
            if (reaction.reaction != TypesOfReaction.None)
            {
                reactionsPending.Add(reaction);
                return;
            }
        }
    }

    private IEnumerator ShowReactions()
    {
        StartedProductivityCalculation();
        yield return new WaitForSeconds(1f);
        while (reactionsPending.Count > 0)
        {
            EmployeeReaction topReaction = reactionsPending[0];
            reactionsPending.Remove(topReaction);
            ShowReaction(topReaction.employee, topReaction.reaction);
            currentProductivity += topReaction.value;

            if (topReaction.value > 0)
                ProductivityIncreased();
            else
                ProductivityDecreased();

            yield return new WaitForSeconds(3f);
            HideReaction();
        }

        finishedEvaluating = true;
        FinishedProductivityCalculation();
    }

    public void ShowReaction(BaseEmployee employee, TypesOfReaction reaction)
    {
        Vector3 newPosition = employee.transform.position;
        newPosition.z = -70;
        reactionBubble.transform.position = newPosition;
        reactionBubble.ShowReaction(reaction);
    }

    public void HideReaction()
    {
        reactionBubble.HideReaction();
    }
}
