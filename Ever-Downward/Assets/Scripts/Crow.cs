using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{

    public void flipCrow()
    {
        //Debug.Log("Ouch my foot");
        gameObject.transform.localRotation = Quaternion.Euler(180, 0, 0);
    }
}
