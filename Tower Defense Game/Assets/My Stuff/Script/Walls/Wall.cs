using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int health;
    private int currentHealth;
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = health;
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
        Destroy(gameObject);
    }

    public void LoseHealth(int dmg)
    {
        currentHealth -= dmg;
        //Debug.Log("wall health = " + health);
    }
}
