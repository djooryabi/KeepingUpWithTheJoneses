using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Transform prefab;
	public float repeateRate=1f;

	// Use this for initialization
	void Start () {
		InvokeRepeating("FireProjectile",0f,repeateRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FireProjectile(){
		Instantiate(prefab, transform.position,transform.rotation);
        GetComponentInChildren<ParticleSystem>().Play();
	}
}
