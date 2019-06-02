using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityController : MonoBehaviour
{
    private PersonalTrait[] employees;

    private bool productivityHasBeenCalculated;

    private List<EmployeeReaction> reactionsPending;

    void Start()
    {
        employees = GetComponentsInChildren<PersonalTrait>();
        reactionsPending = new List<EmployeeReaction>();
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
        foreach (PersonalTrait currentEmployee in employees)
        {
            foreach (PersonalTrait traitPresent in employees)
            {
                TypesOfReaction affectee = currentEmployee.BeAffected(traitPresent, traitPresent.GetPosition());
                TypesOfReaction affected = currentEmployee.AffectOther(traitPresent, traitPresent.GetPosition());

                if (affectee != TypesOfReaction.None)
                {
                    EmployeeReaction affecteeReaction = new EmployeeReaction();
                    affecteeReaction.employee = currentEmployee.GetEmployee();
                    affecteeReaction.reaction = affectee;
                    reactionsPending.Add(affecteeReaction);
                }

                if (affected != TypesOfReaction.None)
                {
                    EmployeeReaction affecteeReaction = new EmployeeReaction();
                    affecteeReaction.employee = traitPresent.GetEmployee();
                    affecteeReaction.reaction = affected;
                    reactionsPending.Add(affecteeReaction);
                }
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
            topReaction.employee.ShowReaction(topReaction.reaction);
            yield return new WaitForSeconds(3f);
            topReaction.employee.HideReaction();
        }
    }
}
