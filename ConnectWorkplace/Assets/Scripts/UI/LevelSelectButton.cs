using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



[RequireComponent(typeof(Button))]
public class LevelSelectButton : GoToLevelButton
{
    [SerializeField]
    private GameObject selectedBorder;

    private bool selected;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        EventManager.StartListening("ClickedLevel", ClickedLevel);
        Select(false);
    }

    private void OnClick()
    {
        //if (!selected)
        //    Select(true);
        //else
            GoToLevel();
    }

    private void Select(bool sel)
    {
        selected = sel;
        selectedBorder.SetActive(sel);
    }

    private void ClickedLevel()
    {
        
    }
}
