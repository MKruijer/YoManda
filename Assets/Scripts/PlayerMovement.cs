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
    public static float OpLadder;
    public float heeftCoin = 0;

	// Use this for initialization
	void Start () {
		//theRB = GetComponent<Rigidbody>();
		controller = GetComponent<CharacterController>();
        RenderSettings.ambientLight = Color.black;
    }
	
	void Update () {
		
        //  Sprint shit
		if(Input.GetKey(KeyCode.LeftShift))
        {
            MovementSpeed = 20;
        }
        else
        {
            MovementSpeed = 10;
        }
		
        //  Berekend de bewegen shit aan de hand van de controller inputs
		float yStore = moveDirection.y;
		moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
		moveDirection = moveDirection * MovementSpeed;
		moveDirection.y = yStore;

		if(controller.isGrounded)	//zorgt ervoor dat je niet oneindig kan springen maar 1x totdat je weer de grond aanraakt.
		{
			moveDirection.y = 0f;
			if(Input.GetButtonDown("Jump"))
		{
			moveDirection.y = jumpForce;
                
		}
		}

        //  Klimmen/ladder shit

        if(GameObject.FindGameObjectsWithTag("Ladder").Length == 1)
        {
            OpLadder = 1;
        }
        else
        {
            OpLadder = 0;
        }

        //  Bewegingen voor wanneer op de ladder
        if(OpLadder == 1)
        {
            moveDirection = (transform.up * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
            moveDirection = moveDirection * 10;
            //moveDirection.y = moveDirection.y + 2;    dit is een geinige omhoog boost
        }
        else
        {
            moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        }

        //  Zorgt voor de beweging
		controller.Move(moveDirection * Time.deltaTime);
	//.normalized	
}
}
