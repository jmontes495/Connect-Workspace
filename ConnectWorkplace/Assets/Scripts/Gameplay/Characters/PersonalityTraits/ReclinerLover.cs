using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReclinerLover : PersonalTrait
{
    private void Start()
    {
        traitType = PersonalityTrait.ReclinerLover;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        if (affectee.GetTraitType() == PersonalityTrait.SuperSerious)
            return TypesOfReaction.None;

        TypesOfReaction reaction = TypesOfReaction.None;
        if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == PersonalityTrait.ReclinerLover)
        {
            affectee.ReduceProductivityBy(10f);
            reaction = TypesOfReaction.ChairClash;
            Debug.LogError(gameObject.name + " hit with the chair " + affectee.gameObject.name);
        }
        return reaction;

    }

    public override TypesOfReaction BeAffected(PersonalTrait affecter, GridPosition theirPosition)
    {
        return TypesOfReaction.None;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Up)
        {
            if (theirPosition.GetRow() == employee.GetPosition().GetRow() + 1)
                return true;
        }
        else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Right)
        {
            if (theirPosition.GetColumn() == employee.GetPosition().GetColumn() - 1)
                return true;
        }
        else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Left)
        {
            if (theirPosition.GetColumn() == employee.GetPosition().GetColumn() + 1)
                return true;
        }
        else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Down)
        {
            if (theirPosition.GetRow() == employee.GetPosition().GetRow() - 1)
                return true;
        }

        return false;
    }
}
