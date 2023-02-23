using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell2 : MonoBehaviour
{
    public bool canCast;
    public GameObject areaOfEffect;
    public int lengthOfSpell;

    void Start()
    {
        canCast = false;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Table" && canCast == true)
        {
            canCast = false;
            StartCoroutine(SpawnSpellAreaOfEffect());
        }
    }
    IEnumerator SpawnSpellAreaOfEffect()
    {
        Instantiate(areaOfEffect, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(lengthOfSpell);
        Destroy(GameObject.FindWithTag("BasicSpellAoE"));
    }
}