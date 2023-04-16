using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private Transform startButtonSlot;

    [SerializeField] private GameObject gameOverText;
    [SerializeField] private Transform gameOverSlot;

    //[SerializeField] private GameObject tutorialLevel;

    [SerializeField] private GameObject defendObject;

    [SerializeField] private GameObject cameraPlane;

    [SerializeField] private GameObject audioManager;

    [SerializeField] private GameObject[] spawners;

    void Awake()
    {
        SpawnStartButton();
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
        audioManager.GetComponent<AdaptiveAudioManager>().gameStarted = true;
        audioManager.GetComponent<AdaptiveAudioManager>().ChangeMusic();
    }

    private void SpawnStartButton()
    {
        Instantiate(startButton, startButtonSlot);
    }

    public void SpawnGameOver()
    {
        Instantiate(gameOverText, gameOverSlot);
        audioManager.GetComponent<AdaptiveAudioManager>().gameStarted = false;
        audioManager.GetComponent<AdaptiveAudioManager>().ChangeMusic();
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

        SpawnStartButton();
    }

    /*private void StartTutorialLevel()
    {
        Instantiate(tutorialLevel);
    }*/
}