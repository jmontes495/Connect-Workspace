using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSensible : PersonalTrait
{
    private void Start()
    {
        traitType = PersonalityTrait.SoundSensible;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        return TypesOfReaction.None;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return false;
    }
}
