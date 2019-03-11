using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeurBewegen : MonoBehaviour {

GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.x > 120 && player.transform.position.x < 144 && gameObject.transform.position.x > 110)
		{

			Vector3 tempPlekkie = transform.position;
			tempPlekkie.x = tempPlekkie.x - 10;
			transform.position = tempPlekkie;
		}
	}
}
