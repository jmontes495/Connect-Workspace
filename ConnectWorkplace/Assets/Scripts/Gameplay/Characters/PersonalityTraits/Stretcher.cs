using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stretcher : PersonalTrait
{
    private void Start()
    {
        traitType = PersonalityTrait.TheStretcher;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        if (affectee.GetTraitType() == PersonalityTrait.SuperSerious)
            return TypesOfReaction.None;

        TypesOfReaction reaction = TypesOfReaction.None;
        if (CheckIfAffectingPosition(theirPosition) && (affectee.GetTraitType() == PersonalityTrait.Otaku || affectee.GetTraitType() == PersonalityTrait.PaperFolder || affectee.GetTraitType() == PersonalityTrait.Thirstee))
        {
            affectee.ReduceProductivityBy(10f);
            switch (affectee.GetTraitType())
            {
                case PersonalityTrait.Otaku:
                    reaction = TypesOfReaction.KnockedFigures;
                    break;
                case PersonalityTrait.PaperFolder:
                    reaction = TypesOfReaction.KnockedOrigami;
                    break;
                case PersonalityTrait.Thirstee:
                    reaction = TypesOfReaction.KnockedWater;
                    break;
            }
            Debug.LogError(gameObject.name + " knocked down the stuff of " + affectee.gameObject.name);
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
