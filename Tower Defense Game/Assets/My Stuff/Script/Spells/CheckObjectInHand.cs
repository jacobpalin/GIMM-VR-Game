using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Audio;

public class CheckObjectInHand : XRDirectInteractor
{
    [SerializeField] private GameObject spellVisibility;
    [SerializeField] private GameObject tutorialManager;

    public void CanCast(string symbol)
    {
        if (tutorialManager.GetComponent<TutorialScript>().spellsSpawned == true)
        {
            tutorialManager.GetComponent<TutorialScript>().tracedSymbol = true;
            tutorialManager.GetComponent<TutorialScript>().TutorialMethod();
        }
        var currentObject = this.selectTarget.gameObject; //sets the currently selected object to the variable
        //var childObject = FindChildWithTag(currentObject); //uses currentObject to call a method to find the child object of the selected object
        if (currentObject.CompareTag("Spell1") && symbol == "Circle")
        {
            //finds the canCast bool and sets it true
            currentObject.GetComponent<Spell1>().canCast = true;
            //plays the ding sound at a varying pitch to sound different every time
            currentObject.GetComponent<AudioSource>().pitch = (Random.Range(0.95f, 1.05f));
            currentObject.GetComponent<AudioSource>().Play();
        }
        else if (currentObject.CompareTag("Spell2") && symbol == "Square")
        {
            currentObject.GetComponent<Spell2>().canCast = true;

            currentObject.GetComponent<AudioSource>().pitch = (Random.Range(0.95f, 1.05f));
            currentObject.GetComponent<AudioSource>().Play();
        }
        else if (currentObject.CompareTag("Spell3") && symbol == "Triangle")
        {
            currentObject.GetComponent<Spell3>().canCast = true;

            currentObject.GetComponent<AudioSource>().pitch = (Random.Range(0.95f, 1.05f));
            currentObject.GetComponent<AudioSource>().Play();
        }
        else if (currentObject.CompareTag("Spell4") && symbol == "V")
        {
            currentObject.GetComponent<Spell4>().canCast = true;

            currentObject.GetComponent<AudioSource>().pitch = (Random.Range(0.95f, 1.05f));
            currentObject.GetComponent<AudioSource>().Play();
        }
    }

    public void HideSpells()
    {
        var currentObject = this.selectTarget.gameObject; //sets the currently selected object to the variable

        if (currentObject.CompareTag("Spell1"))
        {
            spellVisibility.GetComponent<SpellsVisibility>().HideSpell2();
            spellVisibility.GetComponent<SpellsVisibility>().HideSpell3();
            spellVisibility.GetComponent<SpellsVisibility>().HideSpell4();
        }
        else if (currentObject.CompareTag("Spell2"))
        {
            spellVisibility.GetComponent<SpellsVisibility>().HideSpell1();
            spellVisibility.GetComponent<SpellsVisibility>().HideSpell3();
            spellVisibility.GetComponent<SpellsVisibility>().HideSpell4();
        }
        else if (currentObject.CompareTag("Spell3"))
        {
            spellVisibility.GetComponent<SpellsVisibility>().HideSpell1();
            spellVisibility.GetComponent<SpellsVisibility>().HideSpell2();
            spellVisibility.GetComponent<SpellsVisibility>().HideSpell4();
        }
        else if (currentObject.CompareTag("Spell4"))
        {
            spellVisibility.GetComponent<SpellsVisibility>().HideSpell1();
            spellVisibility.GetComponent<SpellsVisibility>().HideSpell2();
            spellVisibility.GetComponent<SpellsVisibility>().HideSpell3();
        }
    }

    /*GameObject FindChildWithTag(GameObject parent)
    {
        GameObject child = null;

        foreach (Transform transform in parent.transform)
        {
            if (transform.tag == "Spell1")
            {
                child = transform.gameObject;
                break;
            }
            else if (transform.tag == "Spell2")
            {
                child = transform.gameObject;
                break;
            }
            else if (transform.tag == "Spell3")
            {
                child = transform.gameObject;
                break;
            }
            else if (transform.tag == "Spell4")
            {
                child = transform.gameObject;
                break;
            }
        }
        return child;
    }*/
}