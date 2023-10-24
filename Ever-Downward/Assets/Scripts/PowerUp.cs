using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Sprite normal;
    public Sprite magic;
    public GameObject wizardOutfit;

    //private AnimatorController animator;
    private Animator playerAnimator;

    private bool wizardPower;
    private bool magicPower;
    private float magicPowerTime=10;
    private float wizardPowerTime=20;
    private float magicTime;
    private float wizardTime;

    // Start is called before the first frame update
    void Start()
    {
        magicTime = 0; wizardTime = 0;
        playerAnimator = GetComponent<Animator>();
        wizardPower = false;
        magicPower = false;
    }

    // Update is called once per frame
    void Update()
    {
        magicPowerCheck();
        wizardPowerCheck();
    }

    //Getters and Setters
    public bool getWizardPower()
    {
        return wizardPower;
    }
    public void setWizardPower(bool w)
    {
        wizardPower=w;
    }

    public bool getMagicPower()
    {
        return magicPower;
    }
    public void setMagicPower(bool m)
    {
        magicPower = m;
    }

    //==========================================================
    //Checker for invincibility power
    private void magicPowerCheck()
    {
        if (magicPower)
        {
            magicSpriteChange();
            invincibility();
            magicTimer();
        }
    }
    //Timer for magic
    private void magicTimer()
    {

        if (magicTime < magicPowerTime)
        {
            magicTime += Time.deltaTime;
        }
        else
        {
            Debug.Log("INVINCIBILITY FINISHED");
            magicPower = false;
            magicTime = 0;
            normalSpriteChange();
            GetComponent<PlayerHealth>().setHealth(2);
        }
    }
    private void invincibility()
    {
        GetComponent<PlayerHealth>().setHealth(999);
    }

    private void magicSpriteChange()
    {
        playerAnimator.SetBool("isMagic", true);
    }

    private void normalSpriteChange()
    {
        playerAnimator.SetBool("isMagic", false);
    }

    //=========================================================
    //Checker for wizard power
    private void wizardPowerCheck()
    {
        if (wizardPower)
        {
            wizardOutfitActivation();
            projectileActivation();
            wizardTimer();
        }
    }

    private void wizardTimer()
    {

        if (wizardTime < wizardPowerTime)
        {
            wizardTime += Time.deltaTime;
        }
        else
        {
            Debug.Log("WIZARD FINISHED");
            wizardOutfit.SetActive(false);
            wizardPower = false;
            wizardTime = 0;
        }
    }

    private void projectileActivation()
    {

    }

    private void wizardOutfitActivation()
    {
        wizardOutfit.SetActive(true);
    }

}
