using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text coinText;
    public Text childDeathText, adultDeathText;
    private int coinsCollected;
    private int childDeathCount;
    private int adultDeathCount;
    
    void Start() {
        coinText.text = "0";
        childDeathText.text = "0";
        adultDeathText.text = "0";
    }

    public void CollectedCoin() {
        coinsCollected++;
        coinText.text = "" + coinsCollected;
    }
    
    public void ChildDied() {
        childDeathCount++;
        childDeathText.text = "" + childDeathCount;
    }
    
    public void AdultDied() {
        adultDeathCount++;
        adultDeathText.text = "" + adultDeathCount;
    }
}
