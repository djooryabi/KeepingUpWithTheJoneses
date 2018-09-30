using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    
	void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }

        instance = this;
    
    }
    
    public void LoadScene(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }
    
    public void QuitGame() {
        Application.Quit();
    }
}
