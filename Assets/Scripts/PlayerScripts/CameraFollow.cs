using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float CameraMoveSpeed = 120.0f;
	public GameObject CameraFollowObj;
	Vector3 FollowPOS;
	public float clampAngle = 80.0f;
	public float inputSensitivity = 150.0f;
	public float camDistanceXToPlayer;
	public float camDistanceYToPlayer;
	public float camDistanceZToPlayer;
	public float mouseX;
	public float mouseY;
	public float finalInputX;
	public float finalInputZ;
	public float smoothX;
	public float smoothY;
	private float rotY = 0.0f;
	private float rotX = 0.0f;


    // Use this for initialization
    void Start () {
        Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {

		// We setup the rotation of the sticks here
		float inputX = Input.GetAxis ("RightStickHorizontal");
		float inputZ = Input.GetAxis ("RightStickVertical");
		mouseX = Input.GetAxis ("Mouse X");
		mouseY = Input.GetAxis ("Mouse Y");
		finalInputX = inputX + mouseX;
		finalInputZ = inputZ + mouseY;

		rotY += finalInputX * inputSensitivity * Time.deltaTime;
		rotX += finalInputZ * inputSensitivity * Time.deltaTime;

		rotX = Mathf.Clamp (rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler (rotX, rotY, 0.0f);
		transform.rotation = localRotation;
        //  zorgt ervoor dat je met rechtermuis de camera (tijdelijk) kan veranderen
        if (!Input.GetMouseButton(1))
        {
            GameObject.Find("Zaklampje").transform.rotation = localRotation;
            GameObject.Find("Player").transform.rotation = Quaternion.Euler(0.0f, rotY, 0.0f);
            
        }
        //  zaklamp aan/uit knop
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (GameObject.Find("Zaklampje").GetComponent<Light>().enabled == false)
            {
                GameObject.Find("Zaklampje").GetComponent<Light>().enabled = true;
            }
            else
            {
                GameObject.Find("Zaklampje").GetComponent<Light>().enabled = false;
            }
        }


    }

	void LateUpdate () {
		CameraUpdater ();
	}

	void CameraUpdater() {
		// set the target object to follow
		Transform target = CameraFollowObj.transform;

		//move towards the game object that is the target
		float step = CameraMoveSpeed * Time.deltaTime;
		transform.position = Vector3.Lerp (transform.position, target.position, step);

	}
}
