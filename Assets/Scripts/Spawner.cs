using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject prefab;
	public float repeateRate=1f;

	// Use this for initialization
	void Start () {
		InvokeRepeating("FireProjectile",Random.Range(0f, 2f),repeateRate);
	}

	void FireProjectile(){
		var go = Instantiate(prefab, transform.position,transform.rotation);
        Destroy(go, 5f);
        GetComponentInChildren<ParticleSystem>().Play();
	}
}
