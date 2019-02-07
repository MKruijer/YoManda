using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartGame : MonoBehaviour {

	// Use this for initialization
	public Camera HomeScreenCamera;
	public Camera firstPersonCamera;
	
	public void ShowFirstPersonView() {
        firstPersonCamera.enabled = false;
        HomeScreenCamera.enabled = false;
    }
}
