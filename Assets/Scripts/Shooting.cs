using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    float gunTime = 0f;
    float timeDelay = .05f;

    public static float bulletScale = 1f;
    public float bonusDMG = 1;
    public float bulletForce = 20;

    public int bombCount;
    public static bool isBomb = false;

    Vector3 temp;

    public static Shooting instance;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Store.isStoreOn)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                bulletScale = 1f;
                Shoot();
                PlayerController.instance.moveSpeed = PlayerController.instance.maxSpeed / 3;
                ScoreManager.instance.numEnemiesKilled -= (bulletScale * PlayerController.instance.baseAttack);
                ScoreManager.instance.Points();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                PlayerController.instance.moveSpeed = PlayerController.instance.maxSpeed;
            }
            if (Input.GetButton("Fire2"))
            {
                Shooting.bulletScale = 1f;
                gunTime = gunTime + 1f * Time.deltaTime;
                if (gunTime >= timeDelay)
                {
                    RapidShoot();
                    ScoreManager.instance.numEnemiesKilled -= 1.5f * (bulletScale * PlayerController.instance.baseAttack);
                    ScoreManager.instance.Points();
                    gunTime = 0f;
                }
            }
            if (Input.GetButtonDown("Fire2"))
            {
                PlayerController.instance.moveSpeed = PlayerController.instance.maxSpeed / 7;
            }
            if (Input.GetButtonUp("Fire2"))
            {
                PlayerController.instance.moveSpeed = PlayerController.instance.maxSpeed;
            }
            if(Input.GetButtonDown("Fire3"))
            {
                if(bombCount >= 1)
                {

                    Debug.Log("BOMB");
                    startBomb();

                }
            }
        }
    }

    void Shoot()
    {
        isBomb = false;
        bonusDMG = 1;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Transform transform = bullet.GetComponent<Transform>();
        bulletScale += bulletScale * 2;
        temp = transform.localScale;
        temp.x = bulletScale;
        temp.y = bulletScale; 
        transform.localScale = temp;
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
    void RapidShoot()
    {
        isBomb = false;
        bonusDMG = 1;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
    void startBomb()
    {
        
        
        for(int i = 0; i < 100; i++)
        {
            bulletScale = 1f;
            bonusDMG = 1;
            
            isBomb = true;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Transform transform = bullet.GetComponent<Transform>();
            bulletScale += bulletScale * 2;
            bonusDMG = 5;
            temp = transform.localScale;
            temp.x = bulletScale;
            temp.y = bulletScale;
            transform.localScale = temp;
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        }
        bombCount--;
        ScoreManager.instance.bombCount();
    }
}
