using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public bool tutorialStarted;
    public bool spellsSpawned;
    public bool pickUpObject;
    public bool tracedSymbol;
    public bool castSpell;

    [SerializeField] private List<GameObject> arrows = new List<GameObject>();

    [SerializeField] private GameObject levelManager;

    [SerializeField] private List<AudioClip> tutorialAudio = new List<AudioClip>();
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        tutorialStarted = false;
        spellsSpawned = false;
        pickUpObject = false;
        tracedSymbol = false;
        castSpell = false;
    }
    public void TutorialMethod()
    {
        if (tutorialStarted == true)
        {
            //play voice line "try pressing the bottom of the 2 buttons on either controller to summon your spells"
            StartCoroutine(PlayAudioClip(tutorialAudio[0]));
        }
        if (tutorialStarted == true && spellsSpawned == true)
        {
            //play voice line "now that you've summoned your spells, try to pick up one by using the grip buttons"
            arrows[0].SetActive(true);
            arrows[1].SetActive(true);
            arrows[2].SetActive(true);
            arrows[3].SetActive(true);
            StartCoroutine(PlayAudioClip(tutorialAudio[1]));
        }
        if (pickUpObject == true && tutorialStarted == true && spellsSpawned == true)
        {
            arrows[0].SetActive(false);
            arrows[1].SetActive(false);
            arrows[2].SetActive(false);
            arrows[3].SetActive(false);
            StartCoroutine(PlayAudioClip(tutorialAudio[2]));
            //play voice line "to activate your spell, hold the trigger and trace your hand in the air to match the shape on the ball. When you've traced the shape, make sure to let go of the trigger and listen for a ding."
        }
        if (tracedSymbol == true && pickUpObject == true && tutorialStarted == true && spellsSpawned == true)
        {
            levelManager.GetComponent<LevelManager>().cameraPlane.GetComponent<CameraPlaneScript>().ScaleUp();
            GameObject[] spawners = levelManager.GetComponent<LevelManager>().spawners;
            foreach (GameObject spawner in spawners)
            {
                spawner.SetActive(true);
            }
            StartCoroutine(PlayAudioClip(tutorialAudio[3]));
            //play voice line "after you've activated your spell, you can now cast the spell by letting go of the grip button to drop it on the seeing floor"
        }
        if (castSpell == true && tracedSymbol == true && pickUpObject == true && tutorialStarted == true && spellsSpawned == true)
        {
            //play voice line "Good luck with the challenges ahead of you seer"
            tutorialStarted = false;
            spellsSpawned = false;
            pickUpObject = false;
            tracedSymbol = false;
            castSpell = false;
            GameObject.FindGameObjectWithTag("TestDefendObject").GetComponent<DefendObject>().currentHealth = 10;
            StartCoroutine(PlayAudioClip(tutorialAudio[4]));
        }
    }

    public IEnumerator PlayAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
    }

    public IEnumerator waitABit()
    {
        yield return new WaitForSeconds(0.1f);
    }
}