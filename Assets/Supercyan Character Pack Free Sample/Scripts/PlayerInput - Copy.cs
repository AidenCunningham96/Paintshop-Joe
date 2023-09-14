using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Character))]
public class PlayerInput : MonoBehaviour
{
    private Character character;
    public Transform cameraPivot;
    public Transform playerCamera;
    public float cameraRotationSpeed = 1;
    public float maxCameraRotationX = 40;
    public float minCameraRotationX = 0;

    //Determines what paint pickups the player has/has not picked up
    public bool BluePickedUp = false;
    public bool YellowPickedUp = false;
    public bool RedPickedUp = false;
    public bool PurplePickedUp = false;

    //Containers for the different paint colors the player can switch to/use
    public Material bluePaint;
    public Material yellowPaint;
    public Material redPaint;
    public Material purplePaint;
    public Material defaultPaint;
    public Material defaultPaint2;
    public Material defaultPaint3;

    //For the XBox controller D-Pad
    public float dpadX;
    public float dpadY;

    public bool cameraControl = false;

    // Use this for initialization
    void Start ()
    {
        character = GetComponent<Character>();

        if (cameraControl)
        {
            cameraPivot.transform.parent = null;
        }
	}

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update ()
    {
        //Camera Pivot Controls

        if (cameraControl)
        {
            cameraPivot.Rotate(Vector3.up, Input.GetAxis("CameraX") * cameraRotationSpeed * Time.deltaTime, Space.World);
            cameraPivot.Rotate(Vector3.right, Input.GetAxis("CameraY") * cameraRotationSpeed * Time.deltaTime, Space.Self);

            if (cameraPivot.rotation.eulerAngles.x > maxCameraRotationX && cameraPivot.rotation.eulerAngles.x < 180)
            {
                cameraPivot.rotation = Quaternion.Euler(maxCameraRotationX, cameraPivot.eulerAngles.y, cameraPivot.eulerAngles.z);
            }

            else if (cameraPivot.rotation.eulerAngles.x < minCameraRotationX && cameraPivot.rotation.eulerAngles.x >= 180)
            {
                cameraPivot.rotation = Quaternion.Euler(minCameraRotationX, cameraPivot.eulerAngles.y, cameraPivot.eulerAngles.z);
            }
        }
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        Vector3 cameraDirection = playerCamera.TransformDirection(inputVector);

        Vector3 motionVector = (new Vector3(cameraDirection.x, 0, cameraDirection.z)).normalized * inputVector.magnitude;

        character.SetMove(motionVector);

        //Channging Colours

        if (Input.GetButtonDown("Jump"))
        {
            character.Jump();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (BluePickedUp == true)
            {
                GameObject.Find("C_man_1_FBX2013").GetComponent<Renderer>().material = bluePaint;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (YellowPickedUp == true)
            {
                GameObject.Find("C_man_1_FBX2013").GetComponent<Renderer>().material = yellowPaint;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (RedPickedUp == true)
            {
                GameObject.Find("C_man_1_FBX2013").GetComponent<Renderer>().material = redPaint;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (PurplePickedUp == true)
            {
                GameObject.Find("C_man_1_FBX2013").GetComponent<Renderer>().material = purplePaint;
            }
        }

        //Changing Colours for the Directional Pad on controller

        dpadX = Input.GetAxis("DpadX");
        dpadY = Input.GetAxis("DpadY");

        if (dpadY > 0)
        {
            if (BluePickedUp == true)
            {
                GameObject.Find("C_man_1_FBX2013").GetComponent<Renderer>().material = bluePaint;
            }
        }

        if (dpadY < 0)
        {
            if (YellowPickedUp == true)
            {
                GameObject.Find("C_man_1_FBX2013").GetComponent<Renderer>().material = yellowPaint;
            }
        }

        if (dpadX > 0)
        {
            if (RedPickedUp == true)
            {
                GameObject.Find("C_man_1_FBX2013").GetComponent<Renderer>().material = redPaint;
            }
        }

        if (dpadX < 0)
        {
            if (PurplePickedUp == true)
            {
                GameObject.Find("C_man_1_FBX2013").GetComponent<Renderer>().material = purplePaint;
            }
        }
    }

    void LateUpdate()
    {
        cameraPivot.transform.position = transform.position;
    }

    public GameObject GetModel()
    {
        return character.model;
    }

}
