using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameQuitter : MonoBehaviour
{
    [SerializeField]
    private Button exitButton;

    [SerializeField]
    private GameObject screen;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        exitButton.onClick.AddListener(ExitGame);
        screen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            screen.SetActive(!screen.activeInHierarchy);
        }
    }


    private void ExitGame()
    {
        Application.Quit();
    }
}
