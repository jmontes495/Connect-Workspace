using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otaku : PersonalTrait
{
    private void Start()
    {
        traitType = TypeOfPersonality.Otaku;
    }

    public override EmployeeReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        EmployeeReaction employeeReaction = new EmployeeReaction();
        employeeReaction.reaction = TypesOfReaction.None;

        if (affectee.GetTraitType() == TypeOfPersonality.SuperSerious)
            return employeeReaction;

        if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == TypeOfPersonality.Otaku)
        {
            affectee.IncreaseProductivityBy(5f);
            employeeReaction.reaction = TypesOfReaction.GoodAnime;
            employeeReaction.value = 5f;
            employeeReaction.employee = affectee.GetEmployee();
            Debug.LogError(gameObject.name + " talked about anime with " + affectee.gameObject.name);
        }

        return employeeReaction;
    }
    
    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckFront(theirPosition) || CheckSides(theirPosition);
    }
}
