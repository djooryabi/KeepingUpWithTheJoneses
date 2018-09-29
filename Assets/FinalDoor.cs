using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour {

    public MeshRenderer doorModel;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    // called when player unlocks the door
    public void Unlock() {
        GetComponent<Collider>().enabled = false;
        doorModel.enabled = false;
    }
}
