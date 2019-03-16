using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {
    public float TopLadder;
    public float Unlocked = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(Unlocked == 1)
        {
            transform.parent.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        if (Unlocked == 0)
        {
            transform.parent.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (Unlocked == 1)
        {
            transform.gameObject.tag = "Ladder";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.gameObject.tag = "Untagged";
    }
}
