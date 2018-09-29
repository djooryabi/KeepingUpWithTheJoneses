using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour {

	public bool isActive = false;
	public bool Activating = false;
	public bool Deactivating = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Activation(){
		Debug.Log("Activating");
		isActive = !isActive;
		Activating = true;
		//Invoke("StopActivation",1f);
	}
	
	public void Deactivation(){
		Debug.Log("Deactivating");
		isActive = !isActive;
		Deactivating = true;
		//Invoke("StopDeactivation",1f);
	}
	
	void StopActivation(){
		Activating = false;
	}

	void StopDeactivation(){
		Deactivating = false;
	}
}
