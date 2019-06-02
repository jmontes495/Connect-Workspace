using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReclinerLover : PersonalTrait
{
    private void Start()
    {
        traitType = PersonalityTrait.ReclinerLover;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        if (affectee.GetTraitType() == PersonalityTrait.SuperSerious)
            return TypesOfReaction.None;

        TypesOfReaction reaction = TypesOfReaction.None;
        if (CheckIfAffectingPosition(theirPosition))
        {
            affectee.ReduceProductivityBy(3f);
            reaction = TypesOfReaction.ChairClash;
            Debug.LogError(gameObject.name + " hit with the chair " + affectee.gameObject.name);
        }
        return reaction;

    }

    public override TypesOfReaction BeAffected(PersonalTrait affecter, GridPosition theirPosition)
    {
        return TypesOfReaction.None;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckBack(theirPosition);
    }
}
