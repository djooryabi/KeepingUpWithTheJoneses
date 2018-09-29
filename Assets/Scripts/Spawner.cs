using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Transform prefab;

	// Use this for initialization
	void Start () {
		InvokeRepeating("FireProjectile",1f,1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FireProjectile(){
		Instantiate(prefab, transform.position,transform.rotation);
	}
}
