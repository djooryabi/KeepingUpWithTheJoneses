using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToggle : MonoBehaviour {

	public bool isSwitched = false;
	public bool toggle = false;
	public GameObject[] prefabs;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			toggle = !toggle;
			if(toggle){
				GetComponent<Renderer>().material.SetColor("_Color",Color.cyan);
			}
			else{GetComponent<Renderer>().material.SetColor("_Color",Color.white);}
			foreach(GameObject prefab in prefabs){
				Debug.Log(prefab.name);
				if(toggle){
					prefab.GetComponent<Activate>().Activation();
				}
				else{
					prefab.GetComponent<Activate>().Deactivation();
				}
			}
		}
	}

	void OnTriggerExit(Collider col){
		
	}
}
