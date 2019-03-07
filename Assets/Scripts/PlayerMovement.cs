using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float MovementSpeed;
	//public Rigidbody theRB;
	public float jumpForce;
	public CharacterController controller;

	private Vector3 moveDirection;
	public float gravityScale;

	// Use this for initialization
	void Start () {
		//theRB = GetComponent<Rigidbody>();
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		

		
		//moveDirection = new Vector3(Input.GetAxis("Horizontal") * MovementSpeed, moveDirection.y, Input.GetAxis("Vertical") * MovementSpeed);
		float yStore = moveDirection.y;
		moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
		moveDirection = moveDirection.normalized * MovementSpeed;
		moveDirection.y = yStore;

		if(controller.isGrounded)	//zorgt ervoor dat je niet oneindig kan springen maar 1x totdat je weer de grond aanraakt.
		{
			moveDirection.y = 0f;
			if(Input.GetButtonDown("Jump"))
		{
			moveDirection.y = jumpForce;
		}
		}

		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
		controller.Move(moveDirection * Time.deltaTime);
	
}
}
