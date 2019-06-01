using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stretcher : PersonalTrait
{
    private void Start()
    {
        traitType = PersonalityTrait.TheStretcher;
    }

    public override void AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        if (CheckIfAffectingPosition(theirPosition) && (affectee.GetTraitType() == PersonalityTrait.Otaku || affectee.GetTraitType() == PersonalityTrait.PaperFolders || affectee.GetTraitType() == PersonalityTrait.Thirstee))
        {
            affectee.ReduceProductivityBy(10f);
            Debug.LogError(gameObject.name + " messed with the stuff of " + affectee.gameObject.name);
        }

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
