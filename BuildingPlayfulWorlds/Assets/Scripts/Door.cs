using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Animator doorAnimation;
    [SerializeField]
    private BoxCollider doorStop;

    private bool playersDirection; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>().HoldsKey)
            tag = "Open";

        if (tag == "Open")
        {
            doorAnimation.Play("DoorAnimation");
            doorStop.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (tag == "Open")
        {
            doorAnimation.Play("DoorCloseAnimation");
            doorStop.enabled = true;
        }
    }
}
