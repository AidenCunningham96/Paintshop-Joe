using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour {
    public PlayerInput player;
    public Character character;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider collider)
    {

        if (collider.tag == "Player")
        {
            return;
        }

        if (collider.tag == "Pickup")
        {
            return;
        }

        if (collider.tag == "Water")
        {
            Physics.gravity = new Vector3(0, -1.1f, 0);
            character.jumpSpeed = 0;
            GameObject.Find("C_man_1_FBX2013").GetComponent<Renderer>().material = GameObject.Find("Player").GetComponent<PlayerInput>().defaultPaint3;
        }

        //Containers for the two colors we are comparing
        if (collider.tag == "Painted")
        {
            Material myColor = player.GetModel().GetComponent<SkinnedMeshRenderer>().sharedMaterial;
            Material otherColor = collider.gameObject.GetComponent<MeshRenderer>().sharedMaterial;

            //If the objects do not have the same material (color), then restart the game
            if (myColor.Equals(otherColor))
            {

            }
            else
            {

                //If the material landed on is not unpainted
                if (otherColor != player.defaultPaint && otherColor != player.defaultPaint2)
                {
                    player.Die();
                    //Debug.Log(otherColor.name);
                }
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
            character.jumpSpeed = 5;
        }
    }
}
