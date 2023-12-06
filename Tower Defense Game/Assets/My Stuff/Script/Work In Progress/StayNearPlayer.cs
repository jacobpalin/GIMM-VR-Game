using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayNearPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z);
    }
}