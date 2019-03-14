using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeurBewegen : MonoBehaviour {

GameObject player;
public int DeurMoetOpen = 0;
public int DeurXOpen;
public int DeurXDicht;
public string DeurXRichting;
    public float snelheid = 10;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		if(GameObject.Find("Door_5") == gameObject)
		{
			DeurXRichting = "Plus";
			DeurXOpen = 153;
			DeurXDicht = 143;
		}
		if(GameObject.Find("Door_6") == gameObject)
		{
			DeurXRichting = "Min";
			DeurXOpen = 110;
			DeurXDicht = 120;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(player.transform.position.x > 120 && player.transform.position.x < 144 && player.transform.position.z > 29 && player.transform.position.z <37)
		{
			DeurMoetOpen = 1;
		}
		else{
			DeurMoetOpen = 0;
		}

		if(DeurMoetOpen == 1)
		{
			DeurOpen(DeurXOpen);
		}
		if(DeurMoetOpen == 0)
		{
			DeurDicht(DeurXDicht);
		}
	}

	public void DeurOpen(int DeurXOpen)
	{
		if(gameObject.transform.position.x < DeurXOpen && DeurXRichting == "Plus")
		{
        Vector3 tempPlekkie = transform.position;
        tempPlekkie.x = tempPlekkie.x + snelheid;
        transform.localPosition = Vector3.Lerp(transform.localPosition, tempPlekkie, Time.deltaTime);
        }

		if(gameObject.transform.position.x > DeurXOpen && DeurXRichting == "Min")
		{
        Vector3 tempPlekkie = transform.position;
        tempPlekkie.x = tempPlekkie.x - snelheid;
        transform.localPosition = Vector3.Lerp(transform.localPosition, tempPlekkie, Time.deltaTime);
        }
	}

	public void DeurDicht(int DeurXDicht)
	{
		if(gameObject.transform.position.x < DeurXDicht && DeurXRichting == "Min" )
		{
        Vector3 tempPlekkie = transform.position;
        tempPlekkie.x = tempPlekkie.x + snelheid;
        transform.localPosition = Vector3.Lerp(transform.localPosition, tempPlekkie, Time.deltaTime);
        }

		if(gameObject.transform.position.x > DeurXDicht && DeurXRichting == "Plus")
		{
        Vector3 tempPlekkie = transform.position;
        tempPlekkie.x = tempPlekkie.x - snelheid;
        transform.localPosition = Vector3.Lerp(transform.localPosition, tempPlekkie, Time.deltaTime);
        }
	}
}
