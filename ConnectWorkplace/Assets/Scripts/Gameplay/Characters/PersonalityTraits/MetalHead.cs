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
        else if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == PersonalityTrait.Metalhead)
        {
            affectee.IncreaseProductivityBy(5f);
            reaction = TypesOfReaction.GoodMusic;
            Debug.LogError(gameObject.name + " shared Ramnstein songs with " + affectee.gameObject.name);
        }
        return reaction;
    }
    
    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckSides(theirPosition);
    }
}
