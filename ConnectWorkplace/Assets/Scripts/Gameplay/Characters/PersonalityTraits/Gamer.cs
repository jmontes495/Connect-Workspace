using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamer : PersonalTrait
{
    private void Start()
    {
        traitType = TypeOfPersonality.Gamer;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        TypesOfReaction reaction = TypesOfReaction.None; 
        if (affectee.GetTraitType() == TypeOfPersonality.SuperSerious)
            return TypesOfReaction.None;

        if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == TypeOfPersonality.Otaku)
        {
            affectee.IncreaseProductivityBy(2f);
            reaction = TypesOfReaction.GoodGames;
            Debug.LogError(gameObject.name + " talked about Death Stranding with " + affectee.gameObject.name);
        }
        else if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == TypeOfPersonality.SoundSensible)
        {
            affectee.ReduceProductivityBy(3f);
            reaction = TypesOfReaction.AnnoyingNoise;
            Debug.LogError(gameObject.name + " with the noise annoyed " + affectee.gameObject.name);
            
        }

        return reaction;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckFront(theirPosition) || CheckSides(theirPosition) || CheckBack(theirPosition);
    }
}
