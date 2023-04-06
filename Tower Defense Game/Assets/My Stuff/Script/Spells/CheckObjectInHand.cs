using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckObjectInHand : XRDirectInteractor
{
    /*public XRDirectInteractor rHand;
    public XRDirectInteractor lHand;*/
    private GameObject activeSpell;

    public void CanCast(string symbol)
    {
        var currentObject = this.selectTarget.gameObject; //sets the currently selected object to the variable
        var childObject = FindChildWithTag(currentObject); //uses currentObject to call a method to find the child object of the selected object
        
        if (childObject.CompareTag("Spell1") && symbol == "Circle")
        {
            childObject.GetComponent<Spell1>().canCast = true;
        }
        else if (childObject.CompareTag("Spell2") && symbol == "Square")
        {
            childObject.GetComponent<Spell2>().canCast = true;
        }
        else if (childObject.CompareTag("Spell3") && symbol == "Triangle")
        {
            childObject.GetComponent<Spell3>().canCast = true;
        }
        else if (childObject.CompareTag("Spell4") && symbol == "V")
        {
            childObject.GetComponent<Spell4>().canCast = true;
        }
    }

    GameObject FindChildWithTag(GameObject parent)
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
    }
}