using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoker : PersonalTrait
{
    override protected void Start()
    {
        traitType = TypeOfPersonality.Smoker;
        base.Start();
    }

    public override EmployeeReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        EmployeeReaction employeeReaction = new EmployeeReaction();
        employeeReaction.reaction = TypesOfReaction.None;

        if (affectee.GetTraitType() == TypeOfPersonality.SuperSerious)
            return employeeReaction;

        if (CheckIfAffectingPosition(theirPosition) && !IsSmoker(affectee))
        {
            affectee.ReduceProductivityBy(6f);
            employeeReaction.reaction = TypesOfReaction.AnnoyingSmoke;
            employeeReaction.value = -6f;
            employeeReaction.employee = affectee.GetEmployee();
            SendDialogue(gameObject.name + " contaminated the air of " + affectee.gameObject.name);
        }
        return employeeReaction;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckSides(theirPosition);
    }

    private bool IsSmoker(PersonalTrait affectee)
    {
        PersonalTrait[] employeeTraits = affectee.gameObject.GetComponents<PersonalTrait>();
        foreach (PersonalTrait trait in employeeTraits)
        {
            if (trait.GetTraitType() == TypeOfPersonality.Smoker)
            {
                return true;
            }
        }
        return false;
    }
}
