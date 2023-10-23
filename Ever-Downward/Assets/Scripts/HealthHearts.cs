using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHearts : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private SpriteRenderer spriteRenderer;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public Sprite magicHeart;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        checkHeartStatus();
    }

    private void checkHeartStatus()
    {
        if (playerHealth.gethealth() > 3)
        {
            magicHeartSpriteChange();
        }
        else if (playerHealth.gethealth() == 2)
        {
            fullHeartSpriteChange();
        }
        else if (playerHealth.gethealth() == 1)
        {
            halfHeartSpriteChange();
        }
        else if (playerHealth.gethealth() == 0)
        {
            emptyHeartSpriteChange();
        }

    }

    private void fullHeartSpriteChange()
    {
        spriteRenderer.sprite = fullHeart;
    }

    private void halfHeartSpriteChange()
    {
        spriteRenderer.sprite= halfHeart;
    }

    private void emptyHeartSpriteChange()
    {
        spriteRenderer.sprite = emptyHeart;
    }
    private void magicHeartSpriteChange()
    {
        spriteRenderer.sprite = magicHeart;
    }
}
