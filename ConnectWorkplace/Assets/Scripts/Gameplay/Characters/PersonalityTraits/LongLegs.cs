using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongLegs : PersonalTrait
{
    private void Start()
    {
        traitType = TypeOfPersonality.LongLegs;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        if (affectee.GetTraitType() == TypeOfPersonality.SuperSerious)
            return TypesOfReaction.None;

        TypesOfReaction reaction = TypesOfReaction.None;

        if (CheckIfAffectingPosition(theirPosition))
        {
            affectee.ReduceProductivityBy(3f);
            reaction = TypesOfReaction.GotKicked;
            Debug.LogError(gameObject.name + " kicked " + affectee.gameObject.name);
        }

        return reaction;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckFront(theirPosition);
    }
}
