using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSerious : PersonalTrait
{
    private void Start()
    {
        traitType = PersonalityTrait.SuperSerious;
    }

    public override void AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        if (affectee.GetTraitType() == PersonalityTrait.SuperSerious)
            return;

        affectee.ReduceProductivityBy(10f);

    }

    public override void BeAffected(PersonalTrait affecter, GridPosition theirPosition)
    {
        // Not necesarrilly affected by anything in particular.
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
