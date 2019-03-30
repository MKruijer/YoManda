using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour {
    private float mouseX;
    private float mouseY;
    private float finalInputX;
    private float finalInputZ;
    private float rotY = 0.0f;
    private float rotX = 0.0f;
    public float inputSensitivity = 150f;
    public float clampAngle = 76.0f;
    // Use this for initialization
    void Start () {
        //pakt de basis rotatie zodat als de player gedraait in het inspawnen staat dat de code nog goed werkt
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        //zorgt dat de muis niet zichtbaar is en wel in de game is gelocked, de muis gaat dus niet uit het scherm
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        //pakt de inputs van de muis
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        //zorgt dat de beweging vloeiend gaat, door middel van sensitivity en de time.deltaTime om het realistisch te maken aan een echte muisbeweging
        rotY += mouseX * inputSensitivity * Time.deltaTime;
        rotX += mouseY* inputSensitivity * Time.deltaTime;
        //Mathf.Clamp zorgt ervoor dat je maar een bepaalde hoeveelheid kan draaien. Door dit toe tepassen zorgen we ervoor dat je tot maximaal boven je zelf kan draaien en niet cirkels om je heen gaat draaien met de camera.
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        //zet de rotatie in veriable, Quaternion is een soort float voor rotaties
        Quaternion localRotation_Camera = Quaternion.Euler(rotX, rotY, 0.0f);
        Quaternion localRotation_Player = Quaternion.Euler(0.0f, rotY, 0.0f);
        //Nu pas je de verandering toe op de camerea/draaing
        if (!Input.GetMouseButton(1))
        {
            //dit is om te zorgen dat je via de rechtermuis je camera vrij kan bewegen.
            GameObject.Find("Player").transform.rotation = localRotation_Player;
        }
        GameObject.Find("CameraLookat").transform.rotation = localRotation_Camera;
        gameObject.transform.LookAt(GameObject.Find("CameraLookat").transform);
    }
}
