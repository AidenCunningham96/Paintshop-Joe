using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePickupScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnTriggerEnter(Collider collision)
    {
        GameObject.Find("Player").GetComponent<PlayerInput>().BluePickedUp = true;
        Destroy(gameObject);
    }
  
}
