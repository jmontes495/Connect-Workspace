using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otaku : PersonalTrait
{
    private void Start()
    {
        traitType = TypeOfPersonality.Otaku;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        TypesOfReaction reaction = TypesOfReaction.None;

        if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == TypeOfPersonality.Otaku)
        {
            affectee.IncreaseProductivityBy(5f);
            reaction = TypesOfReaction.GoodAnime;
            Debug.LogError(gameObject.name + " talked about anime with " + affectee.gameObject.name);
        }

        return reaction;
    }
    
    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckFront(theirPosition) || CheckSides(theirPosition);
    }
}
