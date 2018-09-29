using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	public bool isSwitched = false;
	public bool canDeactivate = false;
	public GameObject[] prefabs;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			isSwitched = true;
			foreach(GameObject prefab in prefabs){
				Debug.Log(prefab.name);
				prefab.GetComponent<Activate>().Activation();
			}
		}
	}

	void OnTriggerExit(Collider col){
		if(canDeactivate){
			isSwitched = false;
			foreach(GameObject prefab in prefabs){
				prefab.GetComponent<Activate>().Deactivation();
			}
		}
	}
}
