using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript_1 : MonoBehaviour
{
    public float speed = 10f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Rotate the object around its local X axis at 1 degree per second
        transform.Rotate(Vector3.down, speed * Time.deltaTime);
    }
}
