using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform respawnPoint;
    private InputManager inputManager;
    private Rigidbody rb;
    private float distanceToGround;
    
    void Awake() {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
    }

    public void Respawn() {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.position = respawnPoint.position;
    }
    
    public bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }
    
    void Update () {
        //Debug.Log(IsGrounded());
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.tag == "Floor")  {
    //        Debug.Log("Grounded");
    //        rb.velocity = Vector3.zero;
    //        rb.angularVelocity = Vector3.zero;
    //    }
    //}
}
