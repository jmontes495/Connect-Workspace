using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalTrait : MonoBehaviour
{
    public enum PersonalityTrait { LongLegs, ReclinerLover, TheStretcher, Otaku, PaperFolders, Thirstee, Metalhead, SocialMediaAddict, Smoker, SmellyPants, SoundSensible, OlorSensible };

    [SerializeField]
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

    protected virtual bool CheckIfAffectingPosition(GridPosition theirPosition)
    {
        return false;
    }

    public GridPosition GetPosition()
    {
        return employee.GetPosition();
    }
}
