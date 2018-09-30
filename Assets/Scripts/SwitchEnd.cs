using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchEnd : MonoBehaviour {

	public bool isSwitched = false;
	public bool canDeactivate = false;

	public GameObject[] prefabs;
	private int players = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			players++;
			if(players >= 2){
				isSwitched = true;
				canDeactivate = false;
				GetComponent<Renderer>().material.SetColor("_Color",Color.green);
				foreach(GameObject prefab in prefabs){
					Debug.Log(prefab.name);
					prefab.GetComponent<Activate>().Activation();
				}
			}
		}
	}

	void OnTriggerExit(Collider col){
		if(col.gameObject.tag == "Player"){
			players--;
			if(canDeactivate){
				if(players < 2){
					isSwitched = false;
					foreach(GameObject prefab in prefabs){
						prefab.GetComponent<Activate>().Deactivation();
					}
				}
			}
		}
		
	}
}
