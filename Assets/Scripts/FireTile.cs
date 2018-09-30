using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTile : MonoBehaviour {

    public bool randomize;
    public ParticleSystem ps;
    private float onTimer, offTimer;
    public float maxOffTime, maxOnTime;

    private bool isPlaying;
    
    void Update() {

        if (randomize == true)
        {
            if (isPlaying == true && onTimer <= 0f)
            {
                ps.gameObject.SetActive(false);
                isPlaying = false;
                GetComponent<Collider>().enabled = false;
                offTimer = maxOffTime;
                //Debug.Log("Fire stopping");
            }
            else if (isPlaying == false && offTimer <= 0f)
            {
                ps.gameObject.SetActive(true);
                isPlaying = true;
                GetComponent<Collider>().enabled = true;
                onTimer = Random.Range(1f, maxOnTime);
                //Debug.Log("Fire starting");
            }

            if (isPlaying == true) {
                onTimer -= Time.deltaTime;
            } else {
                offTimer -= Time.deltaTime;
            }
            
            
        }    
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null && other.GetComponent<Player>().respawning == false) {
            other.GetComponent<Player>().Respawn();
        }
    }

    public void ActivateFire() {
        if (ps.isPlaying == false)
        {
            //Debug.Log("Activating fire");
            ps.Play();
        }
    }
    
    public void DeactivateFire() {
        if (ps.isPlaying == true)
        {
            //Debug.Log("Deactivating fire");
            ps.Stop();
        }
    }
}
