using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public Rigidbody rb;
	public float velX = 1;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.right*velX;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col){

		if(col.gameObject.tag == "Player"){
			Destroy(col.gameObject);
		}

		Destroy(gameObject);
	}
}
