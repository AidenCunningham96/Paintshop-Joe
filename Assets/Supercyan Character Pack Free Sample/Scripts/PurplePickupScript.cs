﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplePickupScript : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider collision)
    {
        GameObject.Find("Player").GetComponent<PlayerInput>().PurplePickedUp = true;
        Destroy(gameObject);
    }

}