using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private float mouseSpeed = 100f;
    private float xRotation = 0f;

    public Transform playerTransform;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed;// * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed;// * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        //transform.localRotation = Quaternion.Euler(xRotation, mouseY, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(xRotation, mouseY, 0), mouseSpeed);
        playerTransform.Rotate(Vector3.up, mouseX);
    }
}
