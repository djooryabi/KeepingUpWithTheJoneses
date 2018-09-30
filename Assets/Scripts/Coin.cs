using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<AdultPlayer>() != null) {
            // collect the coin if its the adult player
            FindObjectOfType<ScoreManager>().CollectedCoin();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<ParticleSystem>().Play();
        } else if (other.GetComponent<ChildPlayer>() != null) {
            // kill the child if he grabs it
            other.GetComponent<ChildPlayer>().Respawn();
        }
    }
}
