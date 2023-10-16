using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
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
        Instantiate(platform, transform.position, transform.rotation);
    }
}
