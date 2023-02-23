using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    public GameObject arrow4;
    public GameObject arrow5;

    public GameObject squareSpell;
    private bool turnOff = false;

    // Start is called before the first frame update
    void Start()
    {
        arrow1.SetActive(true);
        arrow2.SetActive(false);
        arrow3.SetActive(false);
        arrow4.SetActive(false);
        arrow5.SetActive(false);

        squareSpell = GameObject.FindGameObjectWithTag("Spell1");
    }

    private void Update()
    {
        if(squareSpell.GetComponent<Spell1>().canCast == true && turnOff == false)
        {
            turnOff = true;
            ActivateArrow2Second();
        }
    }

    public void ActivateArrow1()
    {
        arrow1.SetActive(true);
        arrow5.SetActive(false);
    }

    public void ActivateArrow2First()
    {
        arrow1.SetActive(false);
        arrow2.SetActive(true);
    }

    public void ActivateArrow3()
    {
        arrow2.SetActive(false);
        arrow3.SetActive(true);
    }

    public void ActivateArrow4()
    {
        arrow3.SetActive(false);
        arrow4.SetActive(true);
    }

    public void ActivateArrow2Second()
    {
        arrow4.SetActive(false);
        arrow2.SetActive(true);
    }

    public void ActivateArrow5()
    {
        arrow2.SetActive(false);
        arrow5.SetActive(true);
    }
}