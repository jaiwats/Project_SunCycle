using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BikeControls : MonoBehaviour
{

    public float speed = 20.0f;
    public float turnSpeed = 5f;
    private float horizontalInput;
    private float forwardInput;
    private float moveForce;
    private float turnForce;

    Rigidbody rb;

    //public InputActionReference joystickReference = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        setForces();
    }

    void setForces()
    {
        moveForce = speed * rb.mass;
        turnForce = turnSpeed * rb.mass / 1000;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Push/turn the object based on arrow key input.
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
        rb.AddForce(forwardInput * moveForce * transform.forward);
        rb.AddTorque(horizontalInput * turnForce * transform.up);
    }
}
