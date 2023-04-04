using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketTagCheck : XRSocketInteractor
{
    public string targetTag = string.Empty;

    public GameObject[] symbolsToSpawn;

    public GameObject SpawnSymbolsHere;

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && MatchTag(interactable);
    }

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && MatchTag(interactable);
    }
    
    private bool MatchTag(XRBaseInteractable interactable)
    {
        return interactable.CompareTag(targetTag);
    }

    //method called by object being put into socket
    public void SpawnSymbol()
    {
        var currentObject = this.selectTarget.gameObject; //sets the currently socketed object to the variable
        var childObject = FindChildWithTag(currentObject); //uses currentObject to call a method to find the child object of the socketed object

        if (childObject.CompareTag("Spell1"))
        {
            GameObject objectToSpawn = Instantiate(symbolsToSpawn[0], SpawnSymbolsHere.transform.position, SpawnSymbolsHere.transform.rotation); //spawns object
            objectToSpawn.transform.SetParent(SpawnSymbolsHere.transform);//sets object as a child of the empty gameObject so that it follows with the table socket
            objectToSpawn.GetComponent<CastCheck>().currentSpell = childObject;
        }
        else if (childObject.CompareTag("Spell2"))
        {
            GameObject objectToSpawn = Instantiate(symbolsToSpawn[1], SpawnSymbolsHere.transform.position, SpawnSymbolsHere.transform.rotation);
            objectToSpawn.transform.SetParent(SpawnSymbolsHere.transform);
            objectToSpawn.GetComponent<CastCheck>().currentSpell = childObject;
        }
        else if (childObject.CompareTag("Spell3"))
        {
            GameObject objectToSpawn = Instantiate(symbolsToSpawn[2], SpawnSymbolsHere.transform.position, SpawnSymbolsHere.transform.rotation);
            objectToSpawn.transform.SetParent(SpawnSymbolsHere.transform);
            objectToSpawn.GetComponent<CastCheck>().currentSpell = childObject;
        }
        else if (childObject.CompareTag("Spell4"))
        {
            GameObject objectToSpawn = Instantiate(symbolsToSpawn[3], SpawnSymbolsHere.transform.position, SpawnSymbolsHere.transform.rotation);
            objectToSpawn.transform.SetParent(SpawnSymbolsHere.transform);
            objectToSpawn.GetComponent<CastCheck>().currentSpell = childObject;
        }

    }

    //method called when object removed from socket
    public void DespawnSymbol()
    {
        if (GameObject.FindGameObjectWithTag("SymbolPrefab"))
        {
            Destroy(GameObject.FindWithTag("SymbolPrefab"));
        }
    }

    //uses the socketed object to find a child object with a specific tag and returns that child to a variable to use a tag on the child
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