using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    private GameObject levelManager;

    void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
    }

    public void RemoveButton()
    {
        levelManager.GetComponent<LevelManager>().RemoveStartButton();
    }
}