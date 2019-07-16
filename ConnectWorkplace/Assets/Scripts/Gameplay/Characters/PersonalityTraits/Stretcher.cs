using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stretcher : PersonalTrait
{
    override protected void Start()
    {
        traitType = TypeOfPersonality.TheStretcher;
        base.Start();
    }

    public override EmployeeReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        EmployeeReaction employeeReaction = new EmployeeReaction();
        employeeReaction.reaction = TypesOfReaction.None;

        if (affectee.GetTraitType() == TypeOfPersonality.SuperSerious)
            return employeeReaction;

        if (CheckIfAffectingPosition(theirPosition) && (affectee.GetTraitType() == TypeOfPersonality.Otaku || affectee.GetTraitType() == TypeOfPersonality.PaperFolder || affectee.GetTraitType() == TypeOfPersonality.Thirstee))
        {
            affectee.ReduceProductivityBy(3f);
            switch (affectee.GetTraitType())
            {
                case TypeOfPersonality.Otaku:
                    employeeReaction.reaction = TypesOfReaction.KnockedFigures;
                    employeeReaction.value = -3f;
                    employeeReaction.employee = affectee.GetEmployee();
                    break;
                case TypeOfPersonality.PaperFolder:
                    employeeReaction.reaction = TypesOfReaction.KnockedOrigami;
                    employeeReaction.value = -3f;
                    employeeReaction.employee = affectee.GetEmployee();
                    break;
                case TypeOfPersonality.Thirstee:
                    employeeReaction.reaction = TypesOfReaction.KnockedWater;
                    employeeReaction.value = -3f;
                    employeeReaction.employee = affectee.GetEmployee();
                    break;
            }
            SendDialogue(gameObject.name + " knocked down the stuff of " + affectee.gameObject.name);
        }
        return employeeReaction;

    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckSides(theirPosition);
    }
}
