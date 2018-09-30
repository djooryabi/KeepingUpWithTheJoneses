using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour {


    private bool wobbling;
    private bool dropping;
    public float speed = 25.0f; //how fast it shakes
    public float amount = 0.1f; //how much it shakes
    public float dropSpeed = 10f;
    public float wiggleTime = 3f;
    public bool testDrop;
    public float respawnTime = 2f;
    private Vector3 originalPosition;
    
    void Awake() {
        originalPosition = transform.position;
    }
    
    public void SetWobbling() {
        wobbling = true;
    }
    
    public void StopWobbling() {
        wobbling = false;
        ResetPosition();
    }
    
    public void Drop() {
        StopWobbling();
        dropping = true;

    }
    
    public void ResetPosition() {
        transform.position = originalPosition;
    }

    //private void OnTriggerEnter(Collider collider)
    //{
    //    Debug.Log("Collided");
    //    if (collider.GetComponent<DeathFloor>() != null) {
    //        Destroy(gameObject);
    //    }
        
    //   //if (collider.GetComponent<>)
    //}
    
    private IEnumerator DropAfterTime() {
        SetWobbling();
        yield return new WaitForSeconds(wiggleTime);
        Drop();
        yield return new WaitForSeconds(respawnTime);
        ResetPosition();
        dropping = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Player>() != null && dropping == false) {
            // wiggle then drop the platform
            StartCoroutine(DropAfterTime());
        }
    }

    void Update() {
        if (testDrop == true) {
            StartCoroutine(DropAfterTime());
            testDrop = false;
        }
        
        if (wobbling == true) {
            var p = transform.position;
            p.x += Mathf.Sin(Time.time * speed) * amount;
            transform.position = p;
        }

        if (dropping == true) {
            transform.Translate(Vector3.down * Time.deltaTime * dropSpeed, Space.World);
        }
        
    }
}
