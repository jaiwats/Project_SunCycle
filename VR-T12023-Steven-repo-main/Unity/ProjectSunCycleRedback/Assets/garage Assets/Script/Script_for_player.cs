using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For UI later
using TMPro;

public class Script_for_player : MonoBehaviour
{
    public float speed;

    public Transform Orientaton;

    private float horizon;
    private float vert;

    private Vector3 MoveDirection;
    

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        MyInput();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizon = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        MoveDirection = Orientaton.forward * vert + Orientaton.right * horizon;

        rb.AddForce(MoveDirection.normalized * speed * 10f, ForceMode.Force);
    }
}
