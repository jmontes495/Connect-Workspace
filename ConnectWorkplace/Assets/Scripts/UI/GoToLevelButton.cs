using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



[RequireComponent(typeof(Button))]
public class GoToLevelButton : MonoBehaviour
{
    [SerializeField]
    private LevelName level = LevelName.LevelSelect;

    protected Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(GoToLevel);
    }

    protected void GoToLevel()
    {
        if (Application.CanStreamedLevelBeLoaded("" + level))
            SceneManager.LoadScene("" + level);
        else
            Debug.LogError("Had an issue loading " + level.ToString());
    }
}
