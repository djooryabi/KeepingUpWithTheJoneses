using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : Activate {

	public float velY = 1f;
	public float distance = -3f;
	public float tripDealy = 1f;
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
			Debug.Log("Drop Platform");
			//transform.Translate(Vector3.up*Time.deltaTime*velY*-1);
			//transform.position = Vector3.MoveTowards(origin, target, velY*Time.deltaTime);
			Invoke("Drop",tripDealy);
			
		}

		if(Deactivating){
			Debug.Log("Lift Platform");
			//transform.Translate(Vector3.up*Time.deltaTime*velY);
			//transform.position = Vector3.MoveTowards(target, origin, velY*Time.deltaTime);
			Invoke("Lift",tripDealy);
		}
	}
	void Drop(){
		transform.position = target;
		Activating = false;
	}
	void Lift(){
		transform.position = origin;
		Deactivating = false;
	}
}
