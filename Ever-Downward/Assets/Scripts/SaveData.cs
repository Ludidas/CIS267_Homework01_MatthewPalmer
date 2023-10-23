using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveData
{
    public static void saveScore(int score)
    {
        if (score > loadScore())
        {
            string path = Application.persistentDataPath + "/playerScore.sc";

            BinaryFormatter bf = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Create);

            bf.Serialize(stream, score);

            stream.Close();
        }

    }

    public static int loadScore()
    {
        string path = Application.persistentDataPath + "/playerScore.sc";

        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            int score = (int)bf.Deserialize(stream);

            stream.Close();

            return score;
        }
        else
        {
            Debug.LogError("File not found in " + path);
            return -1;
        }
    }

    //public List<ScoreClass> LoadData()
    //{
    //    if (File.Exists(path))
    //    {
    //        FileStream stream = new FileStream(path, FileMode.Open);

    //        string[] loadednames = new string[5];
    //        int[] loadedscores = new int[5];
    //        loadedscores = formatter.Deserialize(stream) as int[];
    //        loadednames = formatter.Deserialize(stream) as string[];
    //        List<ScoreClass> loadedList = new List<ScoreClass>();
    //        for (int i = 0; i <= 4; i++)
    //        {
    //            loadedList[i] = new ScoreClass(loadedscores[i], loadednames[i]);

    //        }
    //        return loadedList;

    //    }
    //    else
    //    {
    //        Debug.LogError("save file not found in: " + path);
    //        return null;
    //    }
    //}

}

