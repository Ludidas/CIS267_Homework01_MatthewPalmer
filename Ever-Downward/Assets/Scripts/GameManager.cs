using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerScore playerScore;

    private bool gameOver;
    private float decimalTime=0;

    // Start is called before the first frame update
    void Start()
    {
        setGameOver(false);
    }

    // Update is called once per frame
    void Update()
    {
        timerTick();
    }

    //Game Over========================================
    public bool getGameOver() 
    { 
        return gameOver; 
    }

    public void setGameOver(bool g)
    {
        gameOver = g;
        Debug.Log("Setting Game Over to " + gameOver);
        
        evaluateGameState();
    }

    public void evaluateGameState()
    {
        if (gameOver)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    //================================================

    //Timer===========================================
    public void timerTick()
    {
        if (decimalTime < 1)
        {
            decimalTime += Time.deltaTime;
        }
        else
        {
            playerScore.setDepth(1);
            decimalTime = 0;
        }

    }





}
