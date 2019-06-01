using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



[RequireComponent(typeof(Button))]
public class GoToLevelButton : MonoBehaviour
{
    [SerializeField]
    private LevelName level = LevelName.OfficeGrid;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(GoToLevel);
    }

    private void GoToLevel()
    {
        if (Application.CanStreamedLevelBeLoaded("" + level))
            SceneManager.LoadScene("" + level);
        else
            Debug.LogError("Had an issue loading " + level.ToString());
    }
}
