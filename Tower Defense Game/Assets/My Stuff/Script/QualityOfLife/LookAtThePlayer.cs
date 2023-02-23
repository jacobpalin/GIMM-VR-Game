using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


//found this script from the unity tutorial room project and edited it a tiny bit to work for what i needed
//probably needs a buffer for when it can move so if the player moves slightly then it won't move with the player until after a certain angle threshold
public class LookAtThePlayer : MonoBehaviour
{
    [Tooltip("Toggle to look at or away from player")]
    public bool lookAtOrAway;
    private int one;

    [Tooltip("Follow x axis")]
    public bool lookX = false;

    [Tooltip("Follow y axis")]
    public bool lookY = false;

    [Tooltip("Follow z axis")]
    public bool lookZ = false;

    private GameObject cameraObject = null;
    private Vector3 originalRotation = Vector3.zero;

    private void Awake()
    {
        cameraObject = FindObjectOfType<XRRig>().cameraGameObject;
        originalRotation = transform.eulerAngles;
    }

    private void Update()
    {
        if (lookAtOrAway)
        {
            one = -1;
        }
        else
        {
            one = 1;
        }
        LookAt();
    }

    private void LookAt()
    {
        Vector3 direction = transform.position + (one * cameraObject.transform.position);
        Vector3 newRotation = Quaternion.LookRotation(direction, transform.up).eulerAngles;

        newRotation.x = lookX ? newRotation.x : originalRotation.x;
        newRotation.y = lookY ? newRotation.y : originalRotation.y;
        newRotation.z = lookZ ? newRotation.z : originalRotation.z;

        transform.rotation = Quaternion.Euler(newRotation);
    }
}