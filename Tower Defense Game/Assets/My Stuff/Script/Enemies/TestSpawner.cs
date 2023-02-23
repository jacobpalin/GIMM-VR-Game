using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawner;
    public float spawnTime;
    private float originalTime;

    private void Awake()
    {
        originalTime = spawnTime;
    }
    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0f)
        {
            Instantiate(enemy, spawner.transform.position, Quaternion.identity);
            spawnTime = originalTime;
        }
    }
}