using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell2 : MonoBehaviour
{
    public bool canCast;
    public GameObject areaOfEffect;
    public int lengthOfSpell;

    public Camera terrainCamera;

    void Start()
    {
        canCast = false;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Table" && canCast == true)
        {
            canCast = false;
            RaycastHit hit1;
            Ray ray1 = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray1, out hit1))
            {
                Vector2 localPoint = hit1.textureCoord;
                Ray ray2 = terrainCamera.ViewportPointToRay(localPoint);
                RaycastHit hit2;
                if (Physics.Raycast(ray2, out hit2))
                {
                    StartCoroutine(SpawnSpellAreaOfEffect(hit2.point));
                }
            }
        }
    }
    IEnumerator SpawnSpellAreaOfEffect(Vector3 hit)
    {
        Instantiate(areaOfEffect, hit, Quaternion.identity);
        yield return new WaitForSeconds(lengthOfSpell);
        Destroy(GameObject.FindWithTag("BasicSpellAoE"));
    }
}