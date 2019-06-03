using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSerious : PersonalTrait
{
    private void Start()
    {
        traitType = TypeOfPersonality.SuperSerious;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        if (affectee.GetTraitType() == TypeOfPersonality.SuperSerious)
            return TypesOfReaction.None;

        affectee.ReduceProductivityBy(4f);
        return TypesOfReaction.Stressful;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckSides(theirPosition);
    }
}
