using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSensible : PersonalTrait
{
    override protected void Start()
    {
        traitType = TypeOfPersonality.SoundSensible;
        base.Start();
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
