using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 motionVector = new Vector3(0, 0, 0);
    public GameObject model;
    public Animator anim;
    public float speed = 10;
    public float jumpSpeed;
    private float verticalSpeed;
    public float gravityMultiplier = 1;

	void Start ()
    {
        controller = GetComponent<CharacterController>();
        //anim = model.gameObject.GetComponent<Animator>();
	}
	
	void Update ()
    {
        Vector3 lookVector = new Vector3(motionVector.x, 0, motionVector.z);
        if (lookVector.magnitude > 0)
        {
            anim.transform.forward = lookVector.normalized;
        }

        motionVector += Vector3.up * verticalSpeed;
        controller.Move(motionVector * Time.deltaTime);

        if (!controller.isGrounded)
        {
            verticalSpeed += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }
        else
        {
            verticalSpeed = -1;
        }

        anim.SetBool("Grounded", controller.isGrounded);
        motionVector = Vector3.zero;
	}

    public void SetMove(Vector3 direction)
    {
        anim.SetFloat("MoveSpeed", direction.magnitude);
        motionVector += direction * speed;
    }

    public void Jump()
    {
        if (!controller.isGrounded)
        {
            return;
        }
        else
        {
            verticalSpeed = jumpSpeed;
        }
    }
}
