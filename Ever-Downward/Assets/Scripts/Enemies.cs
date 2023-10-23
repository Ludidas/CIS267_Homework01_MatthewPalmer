using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int enemyDamage;


    public void destroyEnemy()
    {
        Destroy(this.gameObject);
    }

    public int getEnemyDamage()
    {
        return enemyDamage;
    }

    public void setEnemyDamage(int value)
    {
        enemyDamage = value;
    }
}
