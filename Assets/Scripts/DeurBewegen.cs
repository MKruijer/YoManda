using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeurBewegen : MonoBehaviour {

GameObject player;
public int DeurMoetOpen = 0;
public int DeurX1;
public int DeurX2;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		if(GameObject.Find("Door_5") == gameObject)
		{
			DeurX1 = 143;
			DeurX2 = 153;
		}
		if(GameObject.Find("Door_6") == gameObject)
		{
			DeurX1 = 110;
			DeurX2 = 119;
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
			DeurOpen(DeurX1);
		}
		if(DeurMoetOpen == 0)
		{
			DeurDicht(DeurX2);
		}
	}

	public void DeurOpen(int DeurX1)
	{
		if(gameObject.transform.position.x > DeurX1)
		{
		Vector3 tempPlekkie = transform.position;
		tempPlekkie.x--;
		transform.position = tempPlekkie;
		}
	}

	public void DeurDicht(int DeurX2)
	{
		if(gameObject.transform.position.x < DeurX2)
		{
		Vector3 tempPlekkie = transform.position;
		tempPlekkie.x++;
		transform.position = tempPlekkie;
		}
	}
}
