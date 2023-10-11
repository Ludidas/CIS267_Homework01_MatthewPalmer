using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene("InfiniteRunner");
    }

    public void viewScores()
    {
        SceneManager.LoadScene("ScoreMenu");
    }

    public void exitGame()
    {
        //this only works with a build of the game. It will not work when you are playing the game in the unity editor
        Application.Quit();
    }
}
