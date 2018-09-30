using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Treasure : MonoBehaviour {

	public string LoadSceneName = "JackSceneTest";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col){
		if(col.gameObject.tag == "Player"){
			Debug.Log("Treasure Acquired");
			GetComponent<MeshRenderer>().enabled = false;
			GetComponent<AudioSource>().Play();
			Invoke("LoadNextScene",2f);
		}
	}

	void LoadNextScene(){
		SceneManager.LoadScene("Level1");
	}
}
