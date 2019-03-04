using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamreaController : MonoBehaviour {

	public Transform target;

	public Vector3 offset;

	public bool useOffsetValues;

	public float rotateSpeed;
	
	public Transform pivot;

	// Use this for initialization
	void Start () {
		if(!useOffsetValues)
		{
		offset = target.position - transform.position;
		}

		pivot.transform.position = target.transform.position;
		pivot.transform.parent = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = target.position - offset;

		transform.LookAt(target);
	}
}
