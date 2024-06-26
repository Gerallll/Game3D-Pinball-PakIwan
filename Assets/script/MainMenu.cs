using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    private void Start() 
    {
        playButton.onClick.AddListener(PlayGame);
        playButton.onClick.AddListener(ExitGame);

    }
    private void PlayGame()
    {
        SceneManager.LoadScene("PinBallGame");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

}
