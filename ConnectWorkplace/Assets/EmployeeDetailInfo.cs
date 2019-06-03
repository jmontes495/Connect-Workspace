using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeDetailInfo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI employeeName;

    [SerializeField]
    private TextMeshProUGUI trait1;

    [SerializeField]
    private TextMeshProUGUI trait2;

    [SerializeField]
    private TextMeshProUGUI trait3;

    [SerializeField]
    private Button exitButton;

    private void Start()
    {
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(Close);
    }
    public void SetInfo(BaseEmployee theEmployee)
    {
        employeeName.text = theEmployee.gameObject.name;
        PersonalTrait[] employeeTraits = theEmployee.GetComponents<PersonalTrait>();
        trait1.text = employeeTraits.Length >= 1 && employeeTraits[0] != null ? PersonalityDescription.GetTraitDescription(employeeTraits[0].GetTraitType()) : "";
        trait2.text = employeeTraits.Length >= 2 && employeeTraits[1] != null ? PersonalityDescription.GetTraitDescription(employeeTraits[1].GetTraitType()) : "";
        trait3.text = employeeTraits.Length >= 3 && employeeTraits[2] != null ? PersonalityDescription.GetTraitDescription(employeeTraits[2].GetTraitType()) : "";
    }

    private void Close()
    {
        gameObject.SetActive(false);
    }
}
