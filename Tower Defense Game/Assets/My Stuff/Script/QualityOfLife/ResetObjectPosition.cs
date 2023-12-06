using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//https://www.youtube.com/watch?v=G3vKyFXjk1I&ab_channel=DanielStringer

public class ResetObjectPosition : MonoBehaviour
{
    XRGrabInteractable GrabInteractable;

    [Tooltip("The transform that the object will return to")]
    [SerializeField] float resetDelayTime;

    public Transform socketToReturnTo;
    protected bool shouldReturnHome { get; set; }
    bool isController;

    void Awake()
    {
        GrabInteractable = GetComponent<XRGrabInteractable>();
        shouldReturnHome = true;
    }

    private void OnEnable()
    {
        GrabInteractable.selectExited.AddListener(OnSelectExit);
        GrabInteractable.selectEntered.AddListener(OnSelect);
    }

    private void OnDisable()
    {
        GrabInteractable.selectExited.RemoveListener(OnSelectExit);
        GrabInteractable.selectEntered.RemoveListener(OnSelect);
    }

    private void OnSelect(SelectEnterEventArgs arg0) => CancelInvoke("ReturnHome");
    private void OnSelectExit(SelectExitEventArgs arg0) => Invoke(nameof(ReturnHome), resetDelayTime);

    protected virtual void ReturnHome()
    {
        if (shouldReturnHome)
        {
            transform.position = socketToReturnTo.transform.position; 
            transform.GetChild(0).gameObject.SetActive(false);
            Debug.Log("should return");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ControllerCheck(other.gameObject))
        {
            return;
        }

        var socketInteractor = other.gameObject.GetComponent<XRSocketInteractor>();

        if (socketInteractor == null)
        {
            shouldReturnHome = true;
        }

        else if (socketInteractor.CanSelect(GrabInteractable))
        {
            shouldReturnHome = false;
        }
        else
        {
            shouldReturnHome = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (ControllerCheck(other.gameObject))
        {
            return;
        }

        shouldReturnHome = true;
    }

    bool ControllerCheck(GameObject collidedObject)
    {
        isController = collidedObject.gameObject.GetComponent<XRBaseController>() != null ? true : false;
        return isController;
    }
}