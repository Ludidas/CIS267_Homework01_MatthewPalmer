using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platforms;
    public GameObject[] spawnLocations;
    public float spawnRate;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        spawnPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPlatform();
            timer = 0;
        }

    }
    void spawnPlatform()
    {
        int randomIndex;
        int randomSpawn;
        int spawnedTimes=0;
        GameObject spawnedPrefab;
        bool oneSpawn = true;
        


        for(int i = 0; i < spawnLocations.Length; i++)
        {
            randomIndex = Random.Range(0, platforms.Length);
            randomSpawn = Random.Range(0, 2);

            if(randomSpawn.Equals(0) && spawnedTimes<4 || oneSpawn.Equals(true))
            {
                spawnedPrefab = Instantiate(platforms[randomIndex].gameObject);

                spawnedPrefab.transform.position = new Vector2(spawnLocations[i].transform.position.x, spawnLocations[i].transform.position.y);
                spawnedTimes++;
                oneSpawn = false;
            }

        }
    }
}
