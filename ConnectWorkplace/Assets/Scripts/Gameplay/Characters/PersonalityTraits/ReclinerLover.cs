using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReclinerLover : PersonalTrait
{
    private void Start()
    {
        traitType = PersonalityTrait.ReclinerLover;
    }

    public override void AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        if (affectee.GetTraitType() == PersonalityTrait.SuperSerious)
            return;

        if (CheckIfAffectingPosition(theirPosition) && affectee.GetTraitType() == PersonalityTrait.ReclinerLover)
        {
            affectee.ReduceProductivityBy(10f);
            Debug.LogError(gameObject.name + " hit with the chair " + affectee.gameObject.name);
        }

    }

    public override void BeAffected(PersonalTrait affecter, GridPosition theirPosition)
    {
        // Not necesarrilly affected by anything in particular.
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
