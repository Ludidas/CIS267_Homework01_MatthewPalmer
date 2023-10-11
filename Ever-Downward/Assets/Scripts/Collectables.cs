using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public int collectableValue;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void destroyCollectable()
    {
        Destroy(this.gameObject);
    }

    public int getCollectableValue()
    {
        return collectableValue;
    }

    public void setCollectableValue(int value)
    {
        collectableValue = value;
    }
}
