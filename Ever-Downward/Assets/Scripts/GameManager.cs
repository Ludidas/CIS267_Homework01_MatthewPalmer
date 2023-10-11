using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerScore playerScore;

    private bool gameOver;
    private float time;
    

    // Start is called before the first frame update
    void Start()
    {
        setGameOver(false);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timerTick();
    }

    //Game Over========================================
    public bool getGameOver() { return gameOver; }

    public void setGameOver(bool g)
    {
        gameOver = g;
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
        time += Time.deltaTime;
        updateGuiDepth(time);
        //if (time%Time.deltaTime>=1)
        //{

        //    time = 0;
        //}


    }
    public void updateGuiDepth(float time)
    {
        int depth = (int)time;
        //Debug.Log(depth);

        playerScore.setDepth(depth);
        //guiDepth.text = "Time: " + time;
    }
}
