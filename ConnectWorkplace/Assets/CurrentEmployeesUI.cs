using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEmployeesUI : MonoBehaviour
{
    private BaseEmployee[] employees;

    [SerializeField]
    private GameObject namePrefab;

    [SerializeField]
    private EmployeeDetailInfo employeeDetailInfo;

    private RectTransform namesContainer;
    // Start is called before the first frame update
    void Start()
    {
        namesContainer = GetComponent<RectTransform>();
        employees = Object.FindObjectsOfType<BaseEmployee>();
        foreach (BaseEmployee currentEmployee in employees)
        {
            GameObject employeeName = Instantiate(namePrefab) as GameObject;
            employeeName.transform.SetParent(namesContainer);
            employeeName.transform.localScale = Vector3.one;
            Vector3 position = employeeName.transform.localPosition;
            position.z = -100;
            employeeName.transform.localPosition = position;
            employeeName.GetComponent<EmployeeNameUI>().InitializeEmployee(currentEmployee, this);
        }
    }

    public void ShowEmployeeDetail(BaseEmployee employeeOfInterest)
    {
        employeeDetailInfo.gameObject.SetActive(true);
        employeeDetailInfo.SetInfo(employeeOfInterest);
    }
}
