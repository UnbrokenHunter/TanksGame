using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public static EnemyStats instance;

    public float health;
    public float bosshealth;
    public GameObject enemy;
    

    public GameObject deathAnim;

    private void Start()
    {
        instance = this;
        health = SpawnEnemy.SpawnEnemyScript.enemyHP;
        bosshealth = SpawnEnemy.SpawnEnemyScript.bossHP;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if (Shooting.isBomb == false && Shooting.instance.bonusDMG <= 3)
            {
                ScoreManager.instance.numEnemiesKilled += (int)(PlayerController.instance.baseAttack * Shooting.bulletScale) * 3;
            }
            ScoreManager.instance.Points();
            if (gameObject.tag == "Boss")
            {
                if(Shooting.bulletScale > 2)
                {
                    health -= (int)(PlayerController.instance.baseAttack * Shooting.bulletScale * Shooting.instance.bonusDMG);
                }
                else
                {
                    health -= (PlayerController.instance.baseAttack * Shooting.bulletScale/ 2 * Shooting.instance.bonusDMG);
                }

            }
            else
            {
                if (Shooting.bulletScale > 2)
                {
                    bosshealth -= (int)(PlayerController.instance.baseAttack * Shooting.bulletScale * Shooting.instance.bonusDMG);
                }
                else
                {
                    bosshealth -= (PlayerController.instance.baseAttack * Shooting.bulletScale / 2 * Shooting.instance.bonusDMG);
                }
            }

        }
    }

    public void Update()
    {
        if(health <= 0 || bosshealth <= 0)
        {

            Destroy(enemy);
            GameObject effect = Instantiate(deathAnim, transform.position, Quaternion.identity);
            Destroy(effect, .33F);
            Destroy(gameObject);

            SpawnEnemy.SpawnEnemyScript.numEnemiesKilled += 1;
            ScoreManager.instance.NextWaveIn();

        }
    }

}
