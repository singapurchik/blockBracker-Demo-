using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GetNextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(nextScene + 1);
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
