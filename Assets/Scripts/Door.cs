using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Activate {

	public float velY = 1f;
	public float distance = 10f;
	private Vector3 origin;
	private Vector3 target;

	// Use this for initialization
	void Start () {
		origin = transform.position;
		target = new Vector3(transform.position.x,transform.position.y+distance,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if(Activating){
			Debug.Log("Open Door");
			//transform.Translate(Vector3.up*Time.deltaTime*velY*-1);
			//transform.position = Vector3.MoveTowards(origin, target, velY*Time.deltaTime);
			transform.position = target;
			Activating = false;
		}

		if(Deactivating){
			Debug.Log("Close Door");
			//transform.Translate(Vector3.up*Time.deltaTime*velY);
			//transform.position = Vector3.MoveTowards(target, origin, velY*Time.deltaTime);
			transform.position = origin;
			Deactivating = false;
		}
	}
}
