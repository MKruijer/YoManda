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
        //zaklampje aan/uit
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject.Find("Zaklampje").GetComponent<Light>().enabled = !GameObject.Find("Zaklampje").GetComponent<Light>().enabled;
        }

        //  Berekend de bewegen shit aan de hand van de controller inputs
        float yStore = moveDirection.y;
		moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection * MovementSpeed;
		moveDirection.y = yStore;

        //zorgt ervoor dat je niet oneindig kan springen maar 1x totdat je weer de grond aanraakt.
        if (controller.isGrounded)
		{
			moveDirection.y = 0f;
			if(Input.GetButtonDown("Jump"))
		{
			moveDirection.y = jumpForce;
                
		}
		}

        //  Klimmen/ladder shit
        if (GameObject.FindGameObjectsWithTag("Ladder").Length == 1)
        {
            //doet een raycast en kijkt of hij in de directie van de player iets ziet.
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                moveDirection = (transform.up * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
                //keer 10 is om het klimmen een beetje snel te maken. Dit kan ook met een variable/float maar sinds we het hier 1keer gebruiken is dat nu overbodig.
                moveDirection = moveDirection * 10;
            }
            else
            {
                //dit is om te zorgen dat je stil staat op de ladder. Het zit in de else omdat je anders nooit in de Y kan bewegen.
                moveDirection.y = 0f;
            }
        }
        else
        {
            //gewone zwaartekracht
            moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        }

        //  Zorgt voor de beweging
		controller.Move(moveDirection * Time.deltaTime);	
}
}
