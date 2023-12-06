using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    private GameObject levelManager;
    [SerializeField] private GameObject tutorialManager;

    void Awake()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        tutorialManager = GameObject.FindGameObjectWithTag("TutorialManager");
    }

    public void RemoveButton()
    {
        levelManager.GetComponent<LevelManager>().RemoveStartButton();
    }

    public void TutorialButtonPushed()
    {
        tutorialManager.GetComponent<TutorialScript>().tutorialStarted = true;
        tutorialManager.GetComponent<TutorialScript>().TutorialMethod();
        Destroy(GameObject.FindGameObjectWithTag("Start"));
        Destroy(GameObject.FindGameObjectWithTag("TutorialButton"));
        if (GameObject.FindGameObjectWithTag("GameOver"))
        {
            Destroy(GameObject.FindGameObjectWithTag("GameOver"));
        }
        levelManager.GetComponent<LevelManager>().defendObject.SetActive(true);
        GameObject.FindGameObjectWithTag("TestDefendObject").GetComponent<DefendObject>().currentHealth = 100000;
    }
}