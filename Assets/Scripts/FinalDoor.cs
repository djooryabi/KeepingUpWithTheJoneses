using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour {

    public bool testLock, testUnlock;
    public MeshRenderer doorModel;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (testLock == true) {
            Lock();
            testLock = false;
        }
        
        if (testUnlock == true) {
            Unlock();
            testUnlock = false;
        }
	}
    
    // called when player unlocks the door
    public void Unlock() {
        GetComponent<Collider>().enabled = false;
        doorModel.enabled = false;
    }
    
    public void Lock() {
       GetComponent<Collider>().enabled = true;
       doorModel.enabled = true;
    }
}
