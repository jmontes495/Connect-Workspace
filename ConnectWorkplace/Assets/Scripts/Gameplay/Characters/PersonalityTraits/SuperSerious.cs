using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSerious : PersonalTrait
{
    private void Start()
    {
        traitType = TypeOfPersonality.SuperSerious;
    }

    public override EmployeeReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        EmployeeReaction employeeReaction = new EmployeeReaction();
        employeeReaction.reaction = TypesOfReaction.None;

        if (affectee.GetTraitType() == TypeOfPersonality.SuperSerious)
            return employeeReaction;

        affectee.ReduceProductivityBy(4f);
        employeeReaction.reaction = TypesOfReaction.Stressful;
        employeeReaction.value = -4f;
        employeeReaction.employee = affectee.GetEmployee();
        return employeeReaction;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckSides(theirPosition);
    }
}
