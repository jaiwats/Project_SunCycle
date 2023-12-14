using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayButton : MonoBehaviour
{    
    void Update()
    {
        if (Input.GetMouseButtonDown (0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast (ray, out hit)) 
            {
                if(hit.collider.gameObject.name == gameObject.name)
                {
                    //To go to levels
                    SceneManager.LoadScene("CityScene"); 
                } 
            }   
        }
    }
}
