using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour {
    public float Ladder;
    private string UnlockableLadder;
	// Use this for initialization
	void Start () {
        UnlockableLadder = "Ladderklim" + Ladder;
	}
	
	// Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find(UnlockableLadder).GetComponent<Ladder>().Unlocked = 1;
    }
}
