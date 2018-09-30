using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSwitch : MonoBehaviour {


    public GameObject finalPlatform;
    public Vector3 initialPos, finalPos;
    public float lerpRate = 1f;
    private bool raisePlatform;
    private bool doneRaisingPlatform;
    public bool testRaise;
    
    void Update() {
        if (testRaise == true && doneRaisingPlatform == false && raisePlatform == false) {
            raisePlatform = true;
            testRaise = false;
        }
        if (raisePlatform == true && doneRaisingPlatform == false) {
            finalPlatform.transform.localPosition = Vector3.Lerp(finalPlatform.transform.localPosition, finalPos, lerpRate * Time.deltaTime);
        }
        
        if (finalPlatform.transform.localPosition == finalPos) {
            doneRaisingPlatform = true;
            raisePlatform = false;
            //Debug.Log("Done raising platform");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ChildPlayer>() != null && doneRaisingPlatform == false && raisePlatform == false) {
            raisePlatform = true;
        }
    }
}
