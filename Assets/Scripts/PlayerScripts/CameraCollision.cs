using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour {

	public float minDistance = 1.0f;
	public float maxDistance = 4.0f;
	public float smooth = 10.0f;
	Vector3 dollyDir;
	public Vector3 dollyDirAdjusted;
	public float distance;

	// Use this for initialization
	void Awake () {
        //hier worden ze tijdelijk gecreeërt om geen errors te krijgen
		dollyDir = transform.localPosition.normalized;
		distance = transform.localPosition.magnitude;
	}
	
	// Update is called once per frame
	void Update () {
        //hierin zet je vast welke positie de camera "normaal" moet zijn
		Vector3 desiredCameraPos = transform.parent.TransformPoint (dollyDir * maxDistance);
		RaycastHit hit;
        //kijkt of er iets tussen de player en de camera zit
		if (Physics.Linecast (transform.parent.position, desiredCameraPos, out hit)) {
            //hiermee komt de camera naar de rand van het plek waar de raycast collid/raakt. de 0.87 is om te zorgen dat hij net wat ruimte heeft tussen het raakpunt en de camera.
			distance = Mathf.Clamp ((hit.distance * 0.87f), minDistance, maxDistance);
				
				} else {
                    //zorgt ervoor dat de camera weer terug kan
					distance = maxDistance;
				}
                //past de transformatie toe
				transform.localPosition = Vector3.Lerp (transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
	}
}
