using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public float enemySpeed;

    private Transform playerPos;

    // Start is called before the first frame update
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, enemySpeed * Time.deltaTime);

    }
}
