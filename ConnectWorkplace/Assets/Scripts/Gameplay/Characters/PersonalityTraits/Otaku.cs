using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otaku : PersonalTrait
{
    private void Start()
    {
        traitType = PersonalityTrait.Otaku;
    }

    public override void AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        // Not necesarrilly affects others with anything in particular.
    }

    public override void BeAffected(PersonalTrait affecter, GridPosition theirPosition)
    {
        if (CheckIfAffectingPosition(theirPosition) && affecter.GetTraitType() == PersonalityTrait.Otaku)
        {
            employee.IncreaseProductivity(10f);
            Debug.LogError(gameObject.name + " talked about anime with " + affecter.gameObject.name);
        }
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
