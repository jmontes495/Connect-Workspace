using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperFolder : PersonalTrait
{
    override protected void Start()
    {
        traitType = TypeOfPersonality.PaperFolder;
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
            affectee.IncreaseProductivityBy(4f);
            employeeReaction.reaction = TypesOfReaction.HeartfulFigures;
            employeeReaction.value = 4f;
            employeeReaction.employee = affectee.GetEmployee();
            SendDialogue(gameObject.name + " relaxed " + affectee.gameObject.name + " with the paper figurines");
        }
        return employeeReaction;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckFront(theirPosition) || CheckSides(theirPosition);
    }
}
