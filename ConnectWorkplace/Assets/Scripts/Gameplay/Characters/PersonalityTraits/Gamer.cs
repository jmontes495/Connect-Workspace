using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamer : PersonalTrait
{
    override protected void Start()
    {
        traitType = TypeOfPersonality.Gamer;
        base.Start();
    }

    public override EmployeeReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        EmployeeReaction employeeReaction = new EmployeeReaction();
        employeeReaction.reaction = TypesOfReaction.None;

        if (affectee.GetTraitType() == TypeOfPersonality.SuperSerious)
            return employeeReaction;

        if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == TypeOfPersonality.Otaku)
        {
            affectee.IncreaseProductivityBy(4f);
            employeeReaction.reaction = TypesOfReaction.GoodGames;
            employeeReaction.value = 4f;
            employeeReaction.employee = affectee.GetEmployee();
            Debug.LogError(gameObject.name + " talked about Death Stranding with " + affectee.gameObject.name);
        }
        else if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == TypeOfPersonality.SoundSensible)
        {
            affectee.ReduceProductivityBy(3f);
            employeeReaction.reaction = TypesOfReaction.AnnoyingNoise;
            employeeReaction.value = -3f;
            employeeReaction.employee = affectee.GetEmployee();
            Debug.LogError(gameObject.name + " with the noise annoyed " + affectee.gameObject.name);
            
        }

        return employeeReaction;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckFront(theirPosition) || CheckSides(theirPosition) || CheckBack(theirPosition);
    }
}
