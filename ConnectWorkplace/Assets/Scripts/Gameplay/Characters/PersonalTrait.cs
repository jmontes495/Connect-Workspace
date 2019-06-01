using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalTrait : MonoBehaviour
{
    public enum PersonalityTrait { LongLegs, ReclinerLover, TheStretcher, Otaku, PaperFolder, Thirstee, Metalhead, Smoker, SmellyPants, SoundSensible, OlorSensible, Gamer, Pyromaniac, SuperSerious };
    
    protected PersonalityTrait traitType;

    protected BaseEmployee employee;

    private void Start()
    {
        employee = GetComponent<BaseEmployee>();
    }

    public virtual void AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {

    }

    public virtual void BeAffected(PersonalTrait affecter, GridPosition theirPosition)
    {

    }

    public virtual void ReduceProductivityBy(float productivityLost)
    {
        employee.ReduceProductivity(productivityLost);
    }

    public virtual void IncreaseProductivityBy(float productivityGain)
    {
        employee.IncreaseProductivity(productivityGain);
    }

    protected virtual bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return false;
    }

    public GridPosition GetPosition()
    {
        if(employee == null)
            employee = GetComponent<BaseEmployee>();
        return employee.GetPosition();
    }

    public PersonalityTrait GetTraitType()
    {
        return traitType;
    }
}
