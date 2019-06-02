using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoker : PersonalTrait
{
    private void Start()
    {
        traitType = PersonalityTrait.Smoker;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        if (affectee.GetTraitType() == PersonalityTrait.SuperSerious)
            return TypesOfReaction.None;

        TypesOfReaction reaction = TypesOfReaction.None;
        if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() != PersonalityTrait.Smoker)
        {
            affectee.ReduceProductivityBy(6f);
            reaction = TypesOfReaction.AnnoyingSmoke;
            Debug.LogError(gameObject.name + " contaminated the air of " + affectee.gameObject.name);
        }
        return reaction;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckSides(theirPosition);
    }
}
