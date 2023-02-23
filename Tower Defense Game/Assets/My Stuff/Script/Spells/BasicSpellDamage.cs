using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpellDamage : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out TestNavmeshEnemy health))
        {
            //Debug.Log("they should take damage");
            health.LoseHealth(damage);
        }
    }
}
