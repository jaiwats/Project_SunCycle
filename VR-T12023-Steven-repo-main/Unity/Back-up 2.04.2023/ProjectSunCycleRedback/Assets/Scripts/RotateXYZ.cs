using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateXYZ : MonoBehaviour
{
    public float rotateX = 0f;
    public float rotateY = 0f;
    public float rotateZ = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotateX,rotateY,rotateZ) * Time.deltaTime);
    }
}
