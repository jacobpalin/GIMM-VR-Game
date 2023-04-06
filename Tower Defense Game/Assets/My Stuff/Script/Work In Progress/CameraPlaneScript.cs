using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlaneScript : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void ScaleUp()
    {
        animator.ResetTrigger("Idle0Trigger");
        animator.SetTrigger("ScaleUpTrigger");
    }

    public void ScaleDown()
    {
        animator.ResetTrigger("Idle1Trigger");
        animator.SetTrigger("ScaleDownTrigger");
    }

    public void Idle0()
    {
        animator.ResetTrigger("ScaleDownTrigger");
        animator.SetTrigger("Idle0Trigger");
    }
    public void Idle1()
    {
        animator.ResetTrigger("ScaleUpTrigger");
        animator.SetTrigger("Idle1Trigger");
    }
}