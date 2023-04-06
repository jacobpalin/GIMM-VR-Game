using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private Transform startButtonSlot;

    [SerializeField] private GameObject gameOverText;
    [SerializeField] private Transform gameOverSlot;

    [SerializeField] private GameObject tutorialLevel;

    [SerializeField] private GameObject cameraPlane;

    void Awake()
    {
        SpawnStartButton();
    }

    public void RemoveStartButton()
    {
        if (GameObject.FindGameObjectWithTag("GameOver"))
        {
            Destroy(GameObject.FindGameObjectWithTag("GameOver"));
        }
        StartTutorialLevel();
        cameraPlane.GetComponent<CameraPlaneScript>().ScaleUp();
        Destroy(GameObject.FindGameObjectWithTag("Start"));
    }

    private void SpawnStartButton()
    {
        Instantiate(startButton, startButtonSlot);
    }

    public void SpawnGameOver()
    {
        Instantiate(gameOverText, gameOverSlot);

        cameraPlane.GetComponent<CameraPlaneScript>().ScaleDown();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        Destroy(GameObject.FindGameObjectWithTag("TutorialLevel"));
        
        SpawnStartButton();
    }

    private void StartTutorialLevel()
    {
        Instantiate(tutorialLevel);
    }
}