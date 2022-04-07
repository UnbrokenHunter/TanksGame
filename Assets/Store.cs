using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Store : MonoBehaviour
{

    public GameObject storeUI;

    public static Store instance;

    public static bool isStoreOn = false;

    public TMP_Text points;

    public TMP_Text speedPriceText;
    public TMP_Text attackPriceText;
    public TMP_Text healthPriceText;
    public TMP_Text healPriceText;

    public bool nextWave = false;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isStoreOn)
            {
                storeOff();

            }
        }

        if(nextWave == true)
        {
            storeOn();
            nextWave = false;
        }
    }
    public void storeOn()
    {
        storeUI.SetActive(true);
        Time.timeScale = 0f;
        isStoreOn = true;
        ScoreManager.instance.numEnemiesKilled = (int) ScoreManager.instance.numEnemiesKilled;
        points.text = "Points: " + ScoreManager.instance.numEnemiesKilled.ToString();
        refreshStore();
    }

    public void storeOff()
    {
        storeUI.SetActive(false);
        Time.timeScale = 1f;
        isStoreOn = false;
    }

    public void refreshStore()
    {
        ScoreManager.instance.numEnemiesKilled = (int)ScoreManager.instance.numEnemiesKilled;
        points.text = "Points: " + ScoreManager.instance.numEnemiesKilled.ToString();

        speedPriceText.text = BuyItem.instance.speedPrice.ToString() + " Points";
        attackPriceText.text = BuyItem.instance.attackPrice.ToString() + " Points";
        healthPriceText.text = BuyItem.instance.healthPrice.ToString() + " Points";
        healPriceText.text = BuyItem.instance.healPrice.ToString() + " Points";
    }
}
