using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSensible : PersonalTrait
{
    private void Start()
    {
        traitType = TypeOfPersonality.SoundSensible;
    }

    public override EmployeeReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        EmployeeReaction employeeReaction = new EmployeeReaction();
        employeeReaction.reaction = TypesOfReaction.None;
        return employeeReaction;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return false;
    }
}
