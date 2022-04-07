using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, .33F);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Boss")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, .33F);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Wall")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, .33F);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            if(Shooting.isBomb == false)
            {
                //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                //Destroy(effect, .33F);
                //Destroy(gameObject);
            }
        }
        //else if(collision.gameObject.tag == )


    }
}
