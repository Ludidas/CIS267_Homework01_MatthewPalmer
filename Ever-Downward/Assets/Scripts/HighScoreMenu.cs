using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreMenu : MonoBehaviour
{
    public TMP_Text highScore1;
    public TMP_Text highScore2;
    public TMP_Text highScore3;
    public TMP_Text highScore4;
    public TMP_Text highScore5;
    public GameObject resetNotification;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        listScores();
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void listScores()
    {
        //Grab array ints
        int[] scoresList = new int[4];
        scoresList = SaveData.loadScore();


        //Set them to the scores
        highScore1.text = scoresList[0].ToString();
        highScore2.text = scoresList[1].ToString();
        highScore3.text = scoresList[2].ToString();
        highScore4.text = scoresList[3].ToString();
        highScore5.text = scoresList[4].ToString();

    }

    public void resetButton()
    {
        SaveData.resetScore();
        enableScoreResetNotification();
    }

    public void enableScoreResetNotification()
    {
        resetNotification.SetActive(true);
    }
}
