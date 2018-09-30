using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToggle : MonoBehaviour {

	public bool isSwitched = false;
	public bool toggle = false;
	public GameObject[] prefabs;

	void OnTriggerEnter(Collider col){
		if(col.GetComponent<Player>() != null && col.GetComponent<InputManager>().currentToggle != this){
            col.GetComponent<Player>().GetComponent<InputManager>().currentToggle = this;
		}
	}
    
    public void Toggle() {
        toggle = !toggle;
        if(toggle){
            GetComponent<Renderer>().material.SetColor("_Color",Color.cyan);
        }
        else{GetComponent<Renderer>().material.SetColor("_Color",Color.white);}
        
        foreach(GameObject prefab in prefabs){
                //Debug.Log(prefab.name);
                if(toggle){
                    prefab.GetComponent<Activate>().Activation();
                }
                else{
                    prefab.GetComponent<Activate>().Deactivation();
                }
            }
    }

	void OnTriggerExit(Collider col){
		if (col.GetComponent<Player>() != null && col.GetComponent<InputManager>().currentToggle == this) {
            col.GetComponent<InputManager>().currentToggle = null;
        }
	}
}
