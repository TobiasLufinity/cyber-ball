using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void StartGame()
    {
        RestartGame();
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        GameSession gameStatus = FindObjectOfType<GameSession>();
        if(gameStatus)
        {
            gameStatus.ResetGame();
        }
    }


    public void LoadStartScene()
    {
        RestartGame();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
