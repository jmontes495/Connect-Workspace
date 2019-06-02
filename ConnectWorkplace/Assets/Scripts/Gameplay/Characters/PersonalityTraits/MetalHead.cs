using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalHead : PersonalTrait
{
    private void Start()
    {
        traitType = PersonalityTrait.Metalhead;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        if (affectee.GetTraitType() == PersonalityTrait.SuperSerious)
            return TypesOfReaction.None;

        TypesOfReaction reaction = TypesOfReaction.None;
        if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == PersonalityTrait.SoundSensible)
        {
            affectee.ReduceProductivityBy(4f);
            reaction = TypesOfReaction.AnnoyingNoise;
            Debug.LogError(gameObject.name + " with the music annoyed " + affectee.gameObject.name);
        }
        return reaction;
    }

    public override TypesOfReaction BeAffected(PersonalTrait affecter, GridPosition theirPosition)
    {
        TypesOfReaction reaction = TypesOfReaction.None;
        if (CheckIfAffectingPosition(theirPosition) && affecter.GetTraitType() == PersonalityTrait.Metalhead)
        {
            employee.IncreaseProductivity(5f);
            reaction = TypesOfReaction.GoodMusic;
            Debug.LogError(gameObject.name + " shared Ramnstein songs with " + affecter.gameObject.name);
        }
        return reaction;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckSides(theirPosition);
    }
}
