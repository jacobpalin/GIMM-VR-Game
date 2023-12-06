using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private Transform startButtonSlot;
    [SerializeField] private GameObject tutorialButton;
    [SerializeField] private Transform tutorialButtonSlot;

    [SerializeField] private GameObject gameOverText;
    [SerializeField] private Transform gameOverSlot;

    //[SerializeField] private GameObject tutorialLevel;

    [SerializeField] public GameObject defendObject;

    [SerializeField] public GameObject cameraPlane;

    [SerializeField] private GameObject audioManager;

    [SerializeField] public GameObject[] spawners;

    void Awake()
    {
        SpawnButtons();
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject spawner in spawners)
        {
            spawner.SetActive(false);
        }
    }

    public void RemoveStartButton()
    {
        if (GameObject.FindGameObjectWithTag("GameOver"))
        {
            Destroy(GameObject.FindGameObjectWithTag("GameOver"));
        }
        //StartTutorialLevel();
        defendObject.SetActive(true);
        foreach (GameObject spawner in spawners)
        {
            spawner.SetActive(true);
        }
        defendObject.GetComponent<DefendObject>().ResetHealth();
        cameraPlane.GetComponent<CameraPlaneScript>().ScaleUp();
        Destroy(GameObject.FindGameObjectWithTag("Start"));
        Destroy(GameObject.FindGameObjectWithTag("TutorialButton"));
        //audioManager.GetComponent<AdaptiveAudioManager>().gameStarted = true;
        //audioManager.GetComponent<AdaptiveAudioManager>().ChangeMusic();
    }

    private void SpawnButtons()
    {
        Instantiate(startButton, startButtonSlot);
        Instantiate(tutorialButton, tutorialButtonSlot);
    }

    public void SpawnGameOver()
    {
        Instantiate(gameOverText, gameOverSlot);
        //audioManager.GetComponent<AdaptiveAudioManager>().gameStarted = false;
        //audioManager.GetComponent<AdaptiveAudioManager>().ChangeMusic();
        cameraPlane.GetComponent<CameraPlaneScript>().ScaleDown();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        foreach (GameObject spawner in spawners)
        {
            spawner.SetActive(false);
        }

        //Destroy(GameObject.FindGameObjectWithTag("TutorialLevel"));

        SpawnButtons();
    }

    /*private void StartTutorialLevel()
    {
        Instantiate(tutorialLevel);
    }*/
}