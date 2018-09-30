﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	public bool isSwitched = false;
	public bool canDeactivate = false;
	public GameObject[] prefabs;

	public Color colorOn = Color.red;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			isSwitched = true;
			GetComponent<Renderer>().material.SetColor("_Color",colorOn);
			GetComponent<AudioSource>().Play();
			foreach(GameObject prefab in prefabs){
				Debug.Log(prefab.name);
				prefab.GetComponent<Activate>().Activation();
			}
		}
	}

	void OnTriggerExit(Collider col){
		if(canDeactivate){
			isSwitched = false;
			GetComponent<Renderer>().material.SetColor("_Color",Color.white);
			GetComponent<AudioSource>().Stop();
			foreach(GameObject prefab in prefabs){
				prefab.GetComponent<Activate>().Deactivation();
			}
		}
	}
}
