using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float maxSpeed = 10f;
    public float moveSpeed = 10f;
    public float baseAttack = 1f;
    public int maxHP = 9;
    public int health;

    public bool isInvincible = false;

    public Rigidbody2D rb;
    public Camera cam;
    public GameObject UI;

    Vector2 movement;
    Vector2 mousePos;
    public bool shop = false;

    private void Start()
    {
        health = maxHP;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Store.isStoreOn)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            ScoreManager.instance.speedUI();
            ScoreManager.instance.strengthUI();

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            if (health <= -1)
            {
                SceneManager.LoadScene("GameOver");
            }
        }        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg-90f;
        rb.rotation = angle;

    }
     
    private IEnumerator Invincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(0.5f);
        isInvincible = false;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (!isInvincible)
            {
                StartCoroutine(Invincible());
                GameObject hp = GameObject.Find("Life Box").transform.GetChild(health).gameObject;
                health--;
                hp.SetActive(false);

            }
        }
        if (other.tag == "Boss")
        {
            if (!isInvincible)
            {
                StartCoroutine(Invincible());
                GameObject hp = GameObject.Find("Life Box").transform.GetChild(health).gameObject;
                health--;
                hp.SetActive(false);

            }
        }
        if (other.tag == "Wall")
        {
            if (!isInvincible)
            {
                StartCoroutine(Invincible());
                GameObject hp = GameObject.Find("Life Box").transform.GetChild(health).gameObject;
                health--;
                hp.SetActive(false);
            }
        }
    }
}
