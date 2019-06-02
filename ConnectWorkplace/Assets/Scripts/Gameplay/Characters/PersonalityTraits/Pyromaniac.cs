﻿using System.Collections;
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
        if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Up || employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Down)
        {
            if (theirPosition.GetColumn() == employee.GetPosition().GetColumn() - 1 || theirPosition.GetColumn() == employee.GetPosition().GetColumn() + 1)
                return true;
        }
        else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Right || employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Left)
        {
            if (theirPosition.GetRow() == employee.GetPosition().GetRow() + 1 || theirPosition.GetRow() == employee.GetPosition().GetRow() - 1)
                return true;
        }

        return false;
    }
}
