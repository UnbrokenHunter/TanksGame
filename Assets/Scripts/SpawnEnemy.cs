using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public static SpawnEnemy SpawnEnemyScript;

    [SerializeField] public float spawnRadius = 7, time = 1.5f, waveReq = 10, waveNum = 0, numEnemiesSpawned = 0;

    public int numEnemiesKilled = 0;

    private float changeWhat;

    public GameObject[] enemies;
    public GameObject Enemy;
    public GameObject Boss;

    public float enemyHP = 3;
    public float bossHP = 7;


    private void Awake()
    {
        waveNum = 0;
        SpawnEnemyScript = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnAnEnemy());
        Enemy.GetComponent<PlayerFollow>().enemySpeed = 4;
        Boss.GetComponent<PlayerFollow>().enemySpeed = 3;

    }

    private void nextWave()
    {
        waveNum++;
        Store.instance.nextWave = true;

        ScoreManager.instance.AddWave();

        // Every other round start new wave
        
        changeWhat = 1;

        Enemy.GetComponent<PlayerFollow>().enemySpeed += 0.5f;

        if (changeWhat == 1)
        {
            if(time >= 0.4f)
            {
                time -= (float)0.1;
            }
            
            changeWhat = 2;
            enemyHP += 2 * ScoreManager.instance.waveNum;
            bossHP += 3 * ScoreManager.instance.waveNum;
            Debug.Log("HP Increased");
        }
        else if(changeWhat == 2)
        {
            Boss.GetComponent<PlayerFollow>().enemySpeed += 1f;
            if (waveNum <= 13)
            {
                Enemy.GetComponent<PlayerFollow>().enemySpeed += .3f * (float) ScoreManager.instance.waveNum;
                Debug.Log("Speed Increased");
            }
            changeWhat = 1;
        }

        if(waveNum == 3 || waveNum == 7 || waveNum == 14)
        {
            enemyHP += 2;
            bossHP += 3;
            Debug.Log("HP Increased");
        }
        //Store.instance.storeOn();
        if(waveNum >= 6)
        {
            enemyHP += 2 * waveNum;
            bossHP += 3 * waveNum;
            Boss.GetComponent<PlayerFollow>().enemySpeed += 2f;

        }
    }

    IEnumerator SpawnAnEnemy()
    {

        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        float changeBy = 0;

        if(spawnPos.x >= 35)
        {
            changeBy = spawnPos.x - 35f + 5f;
            spawnPos.x -= changeBy;
        }
        if (spawnPos.x <= -35)
        {
            changeBy = spawnPos.x + 15f - 5f;
            spawnPos.x -= changeBy;
        }
        if (spawnPos.y >= 20)
        {
            changeBy = spawnPos.y - 20f + 5f;
            spawnPos.y -= changeBy;
        }
        if (spawnPos.y <= -14)
        {
            changeBy = spawnPos.y + 15f - 5f;
            spawnPos.y -= changeBy;
        }

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);

        numEnemiesSpawned++;

        
        // Start a new Wave
        if(numEnemiesKilled >= waveReq)
        {
            waveReq = (waveReq *= 1.3f) + 10f;
            Debug.Log(waveReq);
            waveReq = (int)waveReq;
            Debug.Log(waveReq);
            nextWave();
        }

        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }
}
