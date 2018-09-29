using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Activate {

	public float velY = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Activating){
			Debug.Log("Open Door");
			transform.Translate(Vector3.up*Time.deltaTime*velY*-1);
		}

		if(Deactivating){
			Debug.Log("Close Door");
			transform.Translate(Vector3.up*Time.deltaTime*velY);
		}
	}
}
