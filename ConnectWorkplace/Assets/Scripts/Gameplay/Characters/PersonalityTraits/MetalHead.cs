using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalHead : PersonalTrait
{
    override protected void Start()
    {
        traitType = TypeOfPersonality.Metalhead;
        base.Start();
    }

    public override EmployeeReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        EmployeeReaction employeeReaction = new EmployeeReaction();
        employeeReaction.reaction = TypesOfReaction.None;

        if (affectee.GetTraitType() == TypeOfPersonality.SuperSerious)
            return employeeReaction;

        if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == TypeOfPersonality.SoundSensible)
        {
            affectee.ReduceProductivityBy(4f);
            employeeReaction.reaction = TypesOfReaction.AnnoyingNoise;
            employeeReaction.value = -4f;
            employeeReaction.employee = affectee.GetEmployee();
            SendDialogue(gameObject.name + " with the music annoyed " + affectee.gameObject.name);
        }
        else if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == TypeOfPersonality.Metalhead)
        {
            affectee.IncreaseProductivityBy(5f);
            employeeReaction.reaction = TypesOfReaction.GoodMusic;
            employeeReaction.value = 5f;
            employeeReaction.employee = affectee.GetEmployee();
            SendDialogue(gameObject.name + " shared Ramnstein songs with " + affectee.gameObject.name);
        }
        return employeeReaction;
    }
    
    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckSides(theirPosition);
    }
}
