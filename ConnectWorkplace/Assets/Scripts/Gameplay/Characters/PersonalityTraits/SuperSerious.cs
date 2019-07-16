using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSerious : PersonalTrait
{
    override protected void Start()
    {
        traitType = TypeOfPersonality.SuperSerious;
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
            affectee.ReduceProductivityBy(2f);
            employeeReaction.reaction = TypesOfReaction.Stressful;
            employeeReaction.value = -2f;
            employeeReaction.employee = affectee.GetEmployee();
            SendDialogue(gameObject.name + " stressed " + affectee.gameObject.name);
        }
        return employeeReaction;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckSides(theirPosition);
    }
}
