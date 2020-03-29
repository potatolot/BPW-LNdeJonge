using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float movingSpeed = 2000f;

    [SerializeField]
    private CharacterController controller;

    private bool holdskey = false;

    public bool HoldsKey { get { return holdskey; } set { holdskey = this; } }
    
    void Update()
    {
        float fowardInput = Input.GetAxis("Horizontal");
        float rightInput = Input.GetAxis("Vertical");

        Vector3 forwardVector = transform.forward * rightInput * movingSpeed;
        Vector3 rightVector = transform.right * fowardInput * movingSpeed;


        controller.SimpleMove(forwardVector + rightVector);

        Debug.Log(holdskey);
        
    }
    
}
