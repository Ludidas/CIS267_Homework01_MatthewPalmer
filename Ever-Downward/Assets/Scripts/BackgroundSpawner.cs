using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject background;
    public GameObject spawnPoint;
    public float spawnRate;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnBackground();
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
            spawnBackground();
            timer = 0;
        }
    }

    void spawnBackground()
    {
        GameObject spawnedPrefab;



        spawnedPrefab = Instantiate(background.gameObject);
        spawnedPrefab.transform.position = new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y);

    }
}
