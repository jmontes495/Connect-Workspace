using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyromaniac : PersonalTrait
{
    private void Start()
    {
        traitType = PersonalityTrait.Pyromaniac;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        TypesOfReaction reaction = TypesOfReaction.None;

        if (affectee.GetTraitType() == PersonalityTrait.SuperSerious)
            return TypesOfReaction.None;

        if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == PersonalityTrait.PaperFolder)
        {
            affectee.ReduceProductivityBy(10f);
            reaction = TypesOfReaction.BurntOrigami;
            Debug.LogError(gameObject.name + " almost burned the figurines of " + affectee.gameObject.name);
        }
        else if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == PersonalityTrait.Smoker)
        {
            affectee.IncreaseProductivityBy(10f);
            reaction = TypesOfReaction.LitCigarrette;
            Debug.LogError(gameObject.name + " lit the cigarretes of " + affectee.gameObject.name);
        }

        return reaction;
    }

    public override TypesOfReaction BeAffected(PersonalTrait affecter, GridPosition theirPosition)
    {
        return TypesOfReaction.None;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckSides(theirPosition);
    }
}
