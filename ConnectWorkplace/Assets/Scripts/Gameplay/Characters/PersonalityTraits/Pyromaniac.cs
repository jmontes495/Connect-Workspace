using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyromaniac : PersonalTrait
{
    override protected void Start()
    {
        traitType = TypeOfPersonality.Pyromaniac;
        base.Start();
    }

    public override EmployeeReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        EmployeeReaction employeeReaction = new EmployeeReaction();
        employeeReaction.reaction = TypesOfReaction.None;

        if (affectee.GetTraitType() == TypeOfPersonality.SuperSerious)
            return employeeReaction;

        if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == TypeOfPersonality.PaperFolder)
        {
            affectee.ReduceProductivityBy(6f);
            employeeReaction.reaction = TypesOfReaction.BurntOrigami;
            employeeReaction.value = -6f;
            employeeReaction.employee = affectee.GetEmployee();
            Debug.LogError(gameObject.name + " almost burned the figurines of " + affectee.gameObject.name);
        }
        else if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == TypeOfPersonality.Smoker)
        {
            affectee.IncreaseProductivityBy(3f);
            employeeReaction.reaction = TypesOfReaction.LitCigarrette;
            employeeReaction.value = 3f;
            employeeReaction.employee = affectee.GetEmployee();
            Debug.LogError(gameObject.name + " lit the cigarretes of " + affectee.gameObject.name);
        }

        return employeeReaction;
    }
    
    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckSides(theirPosition);
    }
}
