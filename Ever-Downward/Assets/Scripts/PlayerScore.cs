using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int depth;
    private int gold;
    public TMP_Text guiDepth;
    public TMP_Text guiGold;

    // Start is called before the first frame update
    void Start()
    {
        depth = 0; gold = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getDepth()
    {
        return depth;
    }
    public int getGold()
    {
        return gold;
    }
    public int getScore()
    {
        return depth+gold;
    }

    public void setDepth(int val)
    {
        depth += val;
        guiDepth.text="Depth: " + depth.ToString();
        //Debug.Log("Depth: " + depth);
    }
    public void setGold(int val)
    {
        gold += val;
        guiGold.text = "Gold: " + gold.ToString();
        //Debug.Log("Gold: " + gold);
    }
}
