using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Lock_move : MonoBehaviour
{
    public Transform CameraPosiotion;
    
    void Update()
    {
        this.gameObject.transform.position = CameraPosiotion.position;
    }
}
