using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoker : PersonalTrait
{
    private void Start()
    {
        traitType = PersonalityTrait.Smoker;
    }

    public override TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        if (affectee.GetTraitType() == PersonalityTrait.SuperSerious)
            return TypesOfReaction.None;

        TypesOfReaction reaction = TypesOfReaction.None;
        if (CheckIfAffectingPosition(theirPosition) && !IsSmoker(affectee))
        {
            affectee.ReduceProductivityBy(6f);
            reaction = TypesOfReaction.AnnoyingSmoke;
            Debug.LogError(gameObject.name + " contaminated the air of " + affectee.gameObject.name);
        }
        return reaction;
    }

    protected override bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return CheckSides(theirPosition);
    }

    private bool IsSmoker(PersonalTrait affectee)
    {
        PersonalTrait[] employeeTraits = affectee.gameObject.GetComponents<PersonalTrait>();
        foreach (PersonalTrait trait in employeeTraits)
        {
            if (trait.GetTraitType() == PersonalityTrait.Smoker)
            {
                return true;
            }
        }
        return false;
    }
}
