using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otaku : PersonalTrait
{
    private void Start()
    {
        traitType = PersonalityTrait.Otaku;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        return TypesOfReaction.None;
    }

    public override TypesOfReaction BeAffected(PersonalTrait affecter, GridPosition theirPosition)
    {
        TypesOfReaction reaction = TypesOfReaction.None;

        if (CheckIfAffectingPosition(theirPosition) && affecter.GetTraitType() == PersonalityTrait.Otaku)
        {
            employee.IncreaseProductivity(5f);
            reaction = TypesOfReaction.GoodAnime;
            Debug.LogError(gameObject.name + " talked about anime with " + affecter.gameObject.name);
        }

        return reaction;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckFront(theirPosition) || CheckSides(theirPosition);
    }
}
