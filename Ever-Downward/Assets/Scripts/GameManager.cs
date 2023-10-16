using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerScore playerScore;

    private bool gameOver;
    private float decimalTime=0f;
    private int time;

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
        decimalTime += Time.deltaTime;
        updateGuiDepth(decimalTime);

    }
    public void updateGuiDepth(float decimalTime)
    {
        //int depth = (int)time;
        time=Mathf.RoundToInt(decimalTime);
        //Debug.Log(depth);

        playerScore.setDepth(time);
        //guiDepth.text = "Time: " + time;
    }



    //public static decimal Truncate(decimal value, int digits)
    //{
    //    double mult = Math.Pow(10.0, digits);
    //    double result = Math.Truncate(mult * value) / mult;
    //    return (float)result;
    //}
}
