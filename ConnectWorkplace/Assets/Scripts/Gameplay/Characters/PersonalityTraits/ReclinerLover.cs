using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReclinerLover : PersonalTrait
{
    override protected void Start()
    {
        traitType = TypeOfPersonality.ReclinerLover;
        base.Start();
    }

    public override EmployeeReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        EmployeeReaction employeeReaction = new EmployeeReaction();
        employeeReaction.reaction = TypesOfReaction.None;

        if (affectee.GetTraitType() == TypeOfPersonality.SuperSerious)
            return employeeReaction;

        if (CheckIfAffectingPosition(theirPosition))
        {
            affectee.ReduceProductivityBy(3f);
            employeeReaction.reaction = TypesOfReaction.ChairClash;
            employeeReaction.value = -3f;
            employeeReaction.employee = affectee.GetEmployee();
            Debug.LogError(gameObject.name + " hit with the chair " + affectee.gameObject.name);
        }
        return employeeReaction;

    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckBack(theirPosition);
    }
}
