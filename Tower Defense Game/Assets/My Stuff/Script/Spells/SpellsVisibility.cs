using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SpellsVisibility : MonoBehaviour
{
    [SerializeField] private List<GameObject> spells = new List<GameObject>();
    [SerializeField] private GameObject movementRecognizer;
    [SerializeField] private GameObject tutorialManager;

    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputThreshold = 0.1f;

    private void Start()
    {
        StartCoroutine(waitABit());
    }

    private void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);

        if (isPressed && movementRecognizer.GetComponent<MovementRecognizer>().pickedUpObject == false)
        {
            ShowSpells();
            if (tutorialManager.GetComponent<TutorialScript>().tutorialStarted == true)
            {
                tutorialManager.GetComponent<TutorialScript>().spellsSpawned = true;
                tutorialManager.GetComponent<TutorialScript>().TutorialMethod();
            }
        }
    }
    public void ShowSpells()
    {
        spells[0].transform.GetChild(0).gameObject.SetActive(true);
        spells[1].transform.GetChild(0).gameObject.SetActive(true);
        spells[2].transform.GetChild(0).gameObject.SetActive(true);
        spells[3].transform.GetChild(0).gameObject.SetActive(true);
    }

    public void HideSpell1()
    {
        spells[0].transform.GetChild(0).gameObject.SetActive(false);
    }

    public void HideSpell2()
    {
        spells[1].transform.GetChild(0).gameObject.SetActive(false);
    }

    public void HideSpell3()
    {
        spells[2].transform.GetChild(0).gameObject.SetActive(false);
    }

    public void HideSpell4()
    {
        spells[3].transform.GetChild(0).gameObject.SetActive(false);
    }

    public IEnumerator waitABit()
    {
        yield return new WaitForSeconds(0.1f);
        HideSpell1();
        HideSpell2();
        HideSpell3();
        HideSpell4();
    }
}