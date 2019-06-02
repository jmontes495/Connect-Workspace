﻿using System.Collections;
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
        else if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == PersonalityTrait.SoundSensible)
        {
            bool affected = false;
            if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Up)
            {
                if (theirPosition.GetRow() == employee.GetPosition().GetRow() + 1)
                    affected = true;
                
            }
            else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Right)
            {
                if (theirPosition.GetColumn() == employee.GetPosition().GetColumn() - 1)
                    affected = true;
            }
            else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Left)
            {
                if (theirPosition.GetColumn() == employee.GetPosition().GetColumn() + 1)
                    affected = true;
            }
            else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Down)
            {
                if (theirPosition.GetRow() == employee.GetPosition().GetRow() - 1)
                    affected = true;
            }

            if (affected)
            {
                affectee.ReduceProductivityBy(10f);
                reaction = TypesOfReaction.AnnoyingNoise;
                Debug.LogError(gameObject.name + " with the noise annoyed " + affectee.gameObject.name);
            }
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
        else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Up)
        {
            if (theirPosition.GetRow() == employee.GetPosition().GetRow() - 1)
                return true;
        }
        else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Right)
        {
            if (theirPosition.GetColumn() == employee.GetPosition().GetColumn() + 1)
                return true;
        }
        else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Left)
        {
            if (theirPosition.GetColumn() == employee.GetPosition().GetColumn() - 1)
                return true;
        }
        else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Down)
        {
            if (theirPosition.GetRow() == employee.GetPosition().GetRow() + 1)
                return true;
        }

        return false;
    }
}
