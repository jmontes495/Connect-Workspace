using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalTrait : MonoBehaviour
{
    public enum PersonalityTrait { LongLegs, ReclinerLover, TheStretcher, Otaku, PaperFolder, Thirstee, Metalhead, Smoker, SmellyPants, SoundSensible, OlorSensible, Gamer, Pyromaniac, SuperSerious };
    
    protected PersonalityTrait traitType;

    [SerializeField]
    protected BaseEmployee employee;

    private void Start()
    {
        employee = GetComponent<BaseEmployee>();
    }

    public virtual TypesOfReaction AffectOther(PersonalTrait affectee, GridPosition theirPosition)
    {
        return TypesOfReaction.None;
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

    protected bool CheckSides(GridPosition theirPosition)
    {
        if ((employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Up || employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Down) && theirPosition.GetRow() == employee.GetPosition().GetRow())
        {
            if (theirPosition.GetColumn() == employee.GetPosition().GetColumn() - 1 || theirPosition.GetColumn() == employee.GetPosition().GetColumn() + 1)
                return true;
        }
        else if ((employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Right || employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Left) && theirPosition.GetColumn() == employee.GetPosition().GetColumn())
        {
            if (theirPosition.GetRow() == employee.GetPosition().GetRow() + 1 || theirPosition.GetRow() == employee.GetPosition().GetRow() - 1)
                return true;
        }

        return false;
    }

    protected bool CheckBack(GridPosition theirPosition)
    {
        if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Up && theirPosition.GetColumn() == employee.GetPosition().GetColumn())
        {
            if (theirPosition.GetRow() == employee.GetPosition().GetRow() + 1)
                return true;
        }
        else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Right && theirPosition.GetRow() == employee.GetPosition().GetRow())
        {
            if (theirPosition.GetColumn() == employee.GetPosition().GetColumn() - 1)
                return true;
        }
        else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Left && theirPosition.GetRow() == employee.GetPosition().GetRow())
        {
            if (theirPosition.GetColumn() == employee.GetPosition().GetColumn() + 1)
                return true;
        }
        else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Down && theirPosition.GetColumn() == employee.GetPosition().GetColumn())
        {
            if (theirPosition.GetRow() == employee.GetPosition().GetRow() - 1)
                return true;
        }

        return false;    
    }

    protected bool CheckFront(GridPosition theirPosition)
    {
        if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Up && theirPosition.GetColumn() == employee.GetPosition().GetColumn())
        {
            if (theirPosition.GetRow() == employee.GetPosition().GetRow() - 1)
                return true;
        }
        else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Right && theirPosition.GetRow() == employee.GetPosition().GetRow())
        {
            if (theirPosition.GetColumn() == employee.GetPosition().GetColumn() + 1)
                return true;
        }
        else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Left && theirPosition.GetRow() == employee.GetPosition().GetRow())
        {
            if (theirPosition.GetColumn() == employee.GetPosition().GetColumn() - 1)
                return true;
        }
        else if (employee.GetPosition().GetOrientation() == GridPosition.FacingOrientation.Down && theirPosition.GetColumn() == employee.GetPosition().GetColumn())
        {
            if (theirPosition.GetRow() == employee.GetPosition().GetRow() + 1)
                return true;
        }

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

    public BaseEmployee GetEmployee()
    {
        return employee;
    }
}
