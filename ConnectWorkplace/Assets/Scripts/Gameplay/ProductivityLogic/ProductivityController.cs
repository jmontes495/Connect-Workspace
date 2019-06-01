using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityController : MonoBehaviour
{
    private PersonalTrait[] employees;

    private bool productivityHasBeenCalculated;

    void Start()
    {
        employees = GetComponentsInChildren<PersonalTrait>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !productivityHasBeenCalculated)
        {
            productivityHasBeenCalculated = true;
            foreach (PersonalTrait currentEmployee in employees)
            {
                foreach (PersonalTrait traitPresent in employees)
                {
                    currentEmployee.BeAffected(traitPresent, traitPresent.GetPosition());
                    currentEmployee.AffectOther(traitPresent, traitPresent.GetPosition());
                }
            }
        }
    }
}
