using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeNameUI : MonoBehaviour
{
    [SerializeField]
    private Button infoButton;

    [SerializeField]
    private TextMeshProUGUI employeeName;

    private CurrentEmployeesUI listController;

    private BaseEmployee employee;

    public void InitializeEmployee(BaseEmployee theEmployee, CurrentEmployeesUI theController)
    {
        employee = theEmployee;
        listController = theController;
        infoButton.onClick.RemoveAllListeners();
        infoButton.onClick.AddListener(ShowEmployeeInfo);
        employeeName.text = employee.gameObject.name;
        employeeName.color = employee.GetColor();
    }

    private void ShowEmployeeInfo()
    {
        listController.ShowEmployeeDetail(employee);
    }


}
