using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public static BuyItem instance;
    public int buyPrice = 100;
    public int speedPrice = 100;
    public int attackPrice = 100;
    public int healthPrice = 100;
    public int healPrice = 100;

    public GameObject HPBar;

    void Start()
    {
        instance = this;
    }

    public void buySpeed()
    {
        if(ScoreManager.instance.numEnemiesKilled >= speedPrice)
        {
            if(PlayerController.instance.maxSpeed <=25)
            {
                PlayerController.instance.maxSpeed += 1;
                ScoreManager.instance.numEnemiesKilled -= speedPrice;
                ScoreManager.instance.Points();
                PlayerController.instance.moveSpeed = PlayerController.instance.maxSpeed;
                speedPrice += 75 * (int)SpawnEnemy.SpawnEnemyScript.waveNum;
                refreshPrices();
            }
        }
    }
    public void buyAttack()
    {
        if (ScoreManager.instance.numEnemiesKilled >= attackPrice)
        {

            PlayerController.instance.baseAttack += 2;
            ScoreManager.instance.numEnemiesKilled -= attackPrice;
            ScoreManager.instance.Points();
            attackPrice += 75 * (int)SpawnEnemy.SpawnEnemyScript.waveNum;
            refreshPrices();
        }
    }
    public void buyHP()
    {
        if (ScoreManager.instance.numEnemiesKilled >= healthPrice)
        {
            if(PlayerController.instance.maxHP <=14)
            {
                PlayerController.instance.maxHP += 1;
                AddHP.instance.addHP();
                ScoreManager.instance.numEnemiesKilled -= healthPrice;
                ScoreManager.instance.Points();
                healthPrice += 150 * (int)SpawnEnemy.SpawnEnemyScript.waveNum;
                refreshPrices();
            }
        }
    }
    public void buyHealth()
    {
        if (ScoreManager.instance.numEnemiesKilled >= healPrice)
        {
            AddHP.instance.refillHP();
            ScoreManager.instance.numEnemiesKilled -= healPrice;
            ScoreManager.instance.Points();
            PlayerController.instance.health = PlayerController.instance.maxHP;
            healPrice += 50;
            refreshPrices();
        }
    }

    public void buyBomb()
    {
        if (ScoreManager.instance.numEnemiesKilled >= 500)
        {
            if(Shooting.instance.bombCount <= 99)
            {
                Shooting.instance.bombCount++;
                ScoreManager.instance.numEnemiesKilled -= 500;
                ScoreManager.instance.Points();
                ScoreManager.instance.bombCount();
                Store.instance.refreshStore();
            }
        }
    }
    public void refreshPrices()
    {
        Store.instance.speedPriceText.text = speedPrice.ToString() + " Points";
        Store.instance.attackPriceText.text = attackPrice.ToString() + " Points";
        Store.instance.healthPriceText.text = healthPrice.ToString() + " Points";
        Store.instance.healPriceText.text = healPrice.ToString() + " Points";
        ScoreManager.instance.numEnemiesKilled = (int)ScoreManager.instance.numEnemiesKilled;
        Store.instance.points.text = "Points: " + ScoreManager.instance.numEnemiesKilled.ToString();

    }
}
