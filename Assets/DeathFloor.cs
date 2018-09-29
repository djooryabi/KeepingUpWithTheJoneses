using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        // Kill the player here
        if (collision.collider.GetComponent<Player>() != null) {
            // respawn the player
            collision.collider.GetComponent<Player>().Respawn();
        }
        
    }
}
