using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject canvas;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Pause();
        }
    }

    public void Pause()
    {
        canvas.gameObject.SetActive(true);
    }
    public void Resume()
    {
        canvas.gameObject.SetActive(false);
    }

}
