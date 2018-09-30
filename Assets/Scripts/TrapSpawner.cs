using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : Activate {

	public GameObject prefab;
	public bool Repeats = false;
	public float repeateRate=1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Activating){
			Debug.Log("Fire Arrows");
			if(Repeats){
				InvokeRepeating("FireProjectile",0f,repeateRate);
			}
			else{
				Invoke("FireProjectile",0f);
			}
			Activating = false;
		}

		if(Deactivating){
			Debug.Log("Stop Firing Arrows");
			CancelInvoke("FireProjectile");
			Deactivating = false;
		}
	}

	void FireProjectile(){
		Instantiate(prefab, transform.position,transform.rotation);
	}
}
