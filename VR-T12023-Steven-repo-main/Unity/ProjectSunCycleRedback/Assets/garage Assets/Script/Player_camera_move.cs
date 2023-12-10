using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_camera_move : MonoBehaviour
{
    private float originSpeed;
    public float sens;

    public Transform Orientaton;

    public float xRotation;
    public float yRotation;
    
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        Orientaton.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
