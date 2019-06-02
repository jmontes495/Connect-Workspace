using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamer : PersonalTrait
{
    private void Start()
    {
        traitType = PersonalityTrait.Gamer;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        TypesOfReaction reaction = TypesOfReaction.None; 
        if (affectee.GetTraitType() == PersonalityTrait.SuperSerious)
            return TypesOfReaction.None;

        if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == PersonalityTrait.Otaku)
        {
            affectee.IncreaseProductivityBy(10f);
            reaction = TypesOfReaction.GoodGames;
            Debug.LogError(gameObject.name + " talked about Death Stranding with " + affectee.gameObject.name);
        }
        else if ((CheckIfAffectingPosition(theirPosition) || CheckBack(theirPosition)) && affectee.GetTraitType() == PersonalityTrait.SoundSensible)
        {
            affectee.ReduceProductivityBy(10f);
            reaction = TypesOfReaction.AnnoyingNoise;
            Debug.LogError(gameObject.name + " with the noise annoyed " + affectee.gameObject.name);
            
        }

        return reaction;
    }

    public override TypesOfReaction BeAffected(PersonalTrait affecter, GridPosition theirPosition)
    {
        return TypesOfReaction.None;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckFront(theirPosition) || CheckSides(theirPosition);
    }
}
