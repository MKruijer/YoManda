using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
    public bool enter = true;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        GameObject.Find("Player").GetComponent<PlayerMovement>().heeftCoin = 1;
    }
}
