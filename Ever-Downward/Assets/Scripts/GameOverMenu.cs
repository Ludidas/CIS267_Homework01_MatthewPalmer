using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject gameOverMenu;
    private GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        gm = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("GameOverMenu update being called " + gm.getGameOver());

        if (gm.getGameOver()==true)
        {
            Debug.Log("gm getGameOver==true functioning");
            showGameOverMenu();
        }
    }

    public void showGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    //==========================================================
    //For buttons to take players away after lose condition
    public void returnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void restartGame()
    {
        gm.setGameOver(false);
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene("InfiniteRunner");
    }

    public void exitGame()
    {
        Application.Quit();
    }
    //=========================================================
}
