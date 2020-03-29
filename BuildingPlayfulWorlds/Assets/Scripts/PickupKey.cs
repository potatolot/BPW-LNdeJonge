using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    [SerializeField]
    private GameObject interectUI;


    private void OnTriggerStay(Collider other)
    {
        
        interectUI.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            other.GetComponent<Player>().HoldsKey = true;

            interectUI.SetActive(false);

            this.gameObject.SetActive(false);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        interectUI.SetActive(false) ;
    }
}
