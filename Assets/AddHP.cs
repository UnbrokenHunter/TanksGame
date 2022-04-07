using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHP : MonoBehaviour
{
    public static AddHP instance;
    public GameObject HPBar;
    private void Start()
    {
        instance = this;
    }
    public void addHP()
    {
        PlayerController.instance.maxHP += 1;
        PlayerController.instance.health += 1;

        GameObject hp = GameObject.Find("Life Box").transform.GetChild(PlayerController.instance.health).gameObject;
        hp.SetActive(true);

    }
    public void refillHP()
    {
        for(int i = 0; i < PlayerController.instance.maxHP; i++) 
        {
            GameObject hp = GameObject.Find("Life Box").transform.GetChild(i).gameObject;
            hp.SetActive(true);
        }
       
    }
}
