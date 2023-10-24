using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SocialPlatforms.Impl;

public class SaveData
{
    
    public static void saveScore(int score)
    {
        //Create new int array
        int[] scoresList = new int[6];
        //Used after sorting
        int[] finalScoresList = new int[6];


        //Grab array from saved file (converted to integer) and save it to loadedScores
        scoresList = loadScore();


        //If score is bigger than the smallest score (Highest score is scoresList[0] and lowest is scoresList[4])
        //There is an extra variable to allow for it to be brought in, sorted, and have the final number in the array ignored
        if (score > scoresList[4])
        {


            for (int i = 0; i < scoresList.Length; i++)
            {
                finalScoresList[i] = scoresList[i];
            }
            finalScoresList[5] = score;



            //Sorts array
            Array.Sort(finalScoresList);

            //Reverses array descendingly
            Array.Reverse(finalScoresList);


            //Save array
            string path = Application.persistentDataPath + "/playerScore.sc";

            BinaryFormatter bf = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Create);

            //Serialize back into comma separated list
            bf.Serialize(stream, finalScoresList[0] + "," + finalScoresList[1] + "," + finalScoresList[2] + "," + finalScoresList[3] + "," + finalScoresList[4]);

            stream.Close();
        }
    }

    public static int[] loadScore()
    {
        string path = Application.persistentDataPath + "/playerScore.sc";

        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            String loadedScores = (String)bf.Deserialize(stream);

            //========================================================
            //Sorting comma separated List and turning into int array

            int[] nums = Array.ConvertAll(loadedScores.Split(','), int.Parse);


            stream.Close();

            return nums;
        }
        else
        {
            Debug.LogError("File not found in " + path);
            resetScore();
            return null;
        }
    }

    public static void resetScore()
    {
        string path = Application.persistentDataPath + "/playerScore.sc";

        BinaryFormatter bf = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);

        bf.Serialize(stream, "0,0,0,0,0");

        stream.Close();
    }

}

