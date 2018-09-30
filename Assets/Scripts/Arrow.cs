using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	private Rigidbody rb;
	public float velX = 1;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.right*velX;
	}

	void OnTriggerEnter (Collider col){

		if(col.GetComponent<Player>() != null){
            col.GetComponent<Player>().Respawn();
            Destroy(gameObject);
		}
	}
}
