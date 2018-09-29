using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform respawnPoint;
    public PlayerCamera cam;
    private InputManager inputManager;
    private Rigidbody rb;
    private float distanceToGround;
    public bool inTunnel;
    
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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Tunnel Entrance")  {
        
    //        Debug.Log("Entered tunnel");
    //        cam.ZoomIn();
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tunnel Entrance")  {

            if (inTunnel == true)
            {
                inTunnel = false;
                cam.ZoomOut();
            } else {
                inTunnel = true;
                cam.ZoomIn();
            }
        }
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
