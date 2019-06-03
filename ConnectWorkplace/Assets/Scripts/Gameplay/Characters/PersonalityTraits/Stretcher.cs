using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stretcher : PersonalTrait
{
    private void Start()
    {
        traitType = TypeOfPersonality.TheStretcher;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        if (affectee.GetTraitType() == TypeOfPersonality.SuperSerious)
            return TypesOfReaction.None;

        TypesOfReaction reaction = TypesOfReaction.None;
        if (CheckIfAffectingPosition(theirPosition) && (affectee.GetTraitType() == TypeOfPersonality.Otaku || affectee.GetTraitType() == TypeOfPersonality.PaperFolder || affectee.GetTraitType() == TypeOfPersonality.Thirstee))
        {
            affectee.ReduceProductivityBy(3f);
            switch (affectee.GetTraitType())
            {
                case TypeOfPersonality.Otaku:
                    reaction = TypesOfReaction.KnockedFigures;
                    break;
                case TypeOfPersonality.PaperFolder:
                    reaction = TypesOfReaction.KnockedOrigami;
                    break;
                case TypeOfPersonality.Thirstee:
                    reaction = TypesOfReaction.KnockedWater;
                    break;
            }
            Debug.LogError(gameObject.name + " knocked down the stuff of " + affectee.gameObject.name);
        }
        return reaction;

    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckSides(theirPosition);
    }
}
