using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    public TMP_Text wave;
    public TMP_Text untilNextWave;
    public TMP_Text points;
    public TMP_Text speed;
    public TMP_Text strength;
    public TMP_Text bombs;

    public int waveNum = 0;
    float untilNextWaveNum = 10;
    public float numEnemiesKilled = 0;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        wave.text = "Wave: " + waveNum.ToString();
        untilNextWave.text = "Next Wave in: " + untilNextWaveNum.ToString();
        points.text = "Points: " + numEnemiesKilled.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddWave()
    {
        waveNum += 1;
        wave.text = "Wave: " + waveNum.ToString();

    }

    public void NextWaveIn()
    {
        untilNextWaveNum = SpawnEnemy.SpawnEnemyScript.waveReq - SpawnEnemy.SpawnEnemyScript.numEnemiesKilled;
        if(untilNextWaveNum == 0)
        {
            untilNextWaveNum = SpawnEnemy.SpawnEnemyScript.waveReq;
        }
        if(untilNextWaveNum < 0)
        {
            untilNextWaveNum = 10;
        }
        untilNextWave.text = "Next Wave in: " + untilNextWaveNum.ToString();
    }
    public void Points()
    {
        //numEnemiesKilled += 1;

        if(numEnemiesKilled <=0)
        {
            numEnemiesKilled = 0;
        }
        if (numEnemiesKilled >= 9999999)
        {
            numEnemiesKilled = 9999999;
        }
        int pointsCount = (int) numEnemiesKilled;
        points.text = "Points: " + pointsCount.ToString();

    }
    public void strengthUI()
    {
        
        strength.text = "Strength: " + PlayerController.instance.baseAttack.ToString();

    }
    public void speedUI()
    {
        int displaySpeed = (int)PlayerController.instance.moveSpeed;
        speed.text = "Speed: " + displaySpeed.ToString();

    }
    public void bombCount()
    {
        
        bombs.text = "Bombs: " + Shooting.instance.bombCount.ToString();

    }
}
