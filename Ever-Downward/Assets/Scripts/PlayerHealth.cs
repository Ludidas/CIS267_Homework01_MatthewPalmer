using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    
    public int gethealth()
    {
        return health;
    }

    public void setHealth(int h)
    {
        health = h;
    }

    public void increaseHealth(int value)
    {
        if(health < 2)
        {
            health += value;
        }

    }
    public void decreaseHealth(int value) 
    {  
        health -= value;
    }
}
