using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript_2 : MonoBehaviour
{
    public float speed = 10f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its local X axis at 1 degree per second
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
