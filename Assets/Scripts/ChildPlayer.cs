using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildPlayer : Player {

	// Use this for initialization
	void Start () {
        // ignore collisions with adult block objects
        var blocks = GameObject.FindGameObjectsWithTag("AdultBlock");
        
        foreach (var b in blocks) {
            if (b.GetComponent<Collider>() != null) {
                Physics.IgnoreCollision(GetComponent<Collider>(), b.GetComponent<Collider>());
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
