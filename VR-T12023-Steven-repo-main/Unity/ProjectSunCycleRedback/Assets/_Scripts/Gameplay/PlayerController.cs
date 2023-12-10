using UnityEngine;

using System;
using System.Collections;
using System.Net;

using TMPro;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Rigidbody rb;
    
    //For score
    private int score;
    
    public TextMeshProUGUI scoreUI;

    //to store rotation
    private Quaternion OldRotation;
    private int change = 0;
    private string R_Turn = "LOW";
    private string L_Turn = "LOW";


    private void Start()
    {
        /*
        MqttClient client = new MqttClient("broker.emqx.io", 1883, false, null);
        client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
        client.Subscribe(new string[] { "Turn/Right" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
        //client.Subscribe(new string[] { "Turn/Left" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
        private string clientId = Guid.NewGuid().ToString();
        client.Connect(clientId);
        */

        // Get the Rigidbody component attached to the bike GameObject
        rb = GetComponent<Rigidbody>();

        // Freeze rotation along the X and Z axes to prevent tumbling
        rb.freezeRotation = true;

        //to set score to 0
        score = 0;
    }
    
    /*
    static void Client_MqttMsgReceived(object sender, MqttMsgPublishEventArgs e)
    {
        // Handle received message
        string topic = e.Topic;
        string message = System.Text.Encoding.UTF8.GetString(e.Message);
        
        
        if(topic == "Turn/Right"){R_Turn = message;}
        else{L_Turn = message;}
        
        
    }
    */

    // Update is called once per frame
    void Update()
    {
        //To check score
        scoreUI.text = score.ToString();

        // Check for the "W" key press
        if (Input.GetKey(KeyCode.W))
        {
            // Move the cube in the camera's forward direction
            MoveForward();
        }

        if (Input.GetKey(KeyCode.S))
        {
            // Move the cube in the camera's back direction
            MoveBackwards();
        }

        if (Input.GetKey(KeyCode.A) || (L_Turn == "LEFT"))
        {
            // Move the cube in the camera's forward direction
            RotationLeft();
        }

        if (Input.GetKey(KeyCode.D) || (R_Turn == "RIGHT"))
        {
            // Move the cube in the camera's forward direction
            RotationRight();
        }
    }

    void MoveForward()
    {
        // Get the camera's forward direction
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0; // To prevent the bike from moving in the Y-axis

        // Move the bike in the camera's forward direction
        transform.position += cameraForward.normalized * movementSpeed * Time.deltaTime;
    }

    void MoveBackwards()
    {
        // Get the camera's forward direction
        Vector3 cameraBackwards = Camera.main.transform.forward;
        cameraBackwards.y = 0; // To prevent the bike from moving in the Y-axis

        // Move the bike in the camera's forward direction
        transform.position -= cameraBackwards.normalized * movementSpeed * Time.deltaTime;
    }

    void RotationLeft()
    {
        //To make chage in rotation 
        change += 1;
        //To set new rotation
        OldRotation = Quaternion.Euler(rb.transform.rotation.x, rb.transform.rotation.y - change, rb.transform.rotation.z);
        //To make bike go towards new rotation
        rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, OldRotation, 0.05f);
    }

    void RotationRight()
    {
        //To make chage in rotation 
        change -= 1;
        //To set new rotation
        OldRotation = Quaternion.Euler(rb.transform.rotation.x, rb.transform.rotation.y - change, rb.transform.rotation.z);
        //To make bike go towards new rotation
        rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, OldRotation, 0.05f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "1")
        {
            score = score + 1;
            other.gameObject.SetActive(false);
        }

        if(other.tag == "2")
        {
            score = score + 2;
            other.gameObject.SetActive(false);
        }

        if(other.tag == "5")
        {
            score = score + 5;
            other.gameObject.SetActive(false);
        }
    }
}
