using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendObject : MonoBehaviour
{
    public int health;
    public int currentHealth;
    private GameObject levelManager;

    void Awake()
    {
        currentHealth = health;
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        levelManager.GetComponent<LevelManager>().SpawnGameOver();
        //Destroy(gameObject, .1f);
        this.gameObject.SetActive(false);
        //Debug.Log("defend object dead");
    }

    public void LoseHealth(int dmg)
    {
        currentHealth -= dmg;
        //Debug.Log("defend object health = " + currentHealth);
    }

    public void ResetHealth()
    {
        currentHealth = health;
    }
}