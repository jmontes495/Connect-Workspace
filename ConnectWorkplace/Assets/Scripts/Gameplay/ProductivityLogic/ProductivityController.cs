using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityController : MonoBehaviour
{
    private BaseEmployee[] employees;

    private bool productivityHasBeenCalculated;

    private List<EmployeeReaction> reactionsPending;

    private ReactionBubble reactionBubble;

    void Start()
    {
        employees = GetComponentsInChildren<BaseEmployee>();
        reactionsPending = new List<EmployeeReaction>();
        reactionBubble = GetComponentInChildren<ReactionBubble>();
        HideReaction();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !productivityHasBeenCalculated)
        {
            CalculateReactions();
            productivityHasBeenCalculated = true;
            StartCoroutine(ShowReactions());
        }
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
        TypesOfReaction reaction = TypesOfReaction.None;
        foreach (PersonalTrait trait in employeeTraits)
        {
            reaction = theTrait.AffectOther(trait, trait.GetPosition());

            if (reaction != TypesOfReaction.None)
            {
                EmployeeReaction reacted = new EmployeeReaction();
                reacted.reaction = reaction;
                reacted.employee = theEmployee;
                reactionsPending.Add(reacted);
                return;
            }
        }
    }

    private IEnumerator ShowReactions()
    {
        yield return new WaitForSeconds(1f);
        while (reactionsPending.Count > 0)
        {
            EmployeeReaction topReaction = reactionsPending[0];
            reactionsPending.Remove(topReaction);
            ShowReaction(topReaction.employee, topReaction.reaction);
            yield return new WaitForSeconds(3f);
            HideReaction();
        }
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
