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
    private Animator anim;
    public float gravityModifier;
    
    void Awake() {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
        anim = GetComponent<Animator>();
    }

    public void Respawn() {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.position = respawnPoint.position;
    }
    
    public bool IsGrounded() {
        Debug.DrawLine(transform.position, transform.position - Vector3.up * (distanceToGround + 0.5f), Color.green);
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.5f);
    }
    
    void Update () {
        //Debug.Log(IsGrounded());
    }

    private void FixedUpdate()
    {
        rb.AddForce(rb.mass * Physics.gravity * gravityModifier, ForceMode.Acceleration);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Tunnel Entrance")  {

    //        Debug.Log("Entered tunnel");
    //        cam.ZoomIn();
    //    }
    //}

    //private void OnCo(Collider other)
    //{
    //    if (other.gameObject.tag == "Floor" && anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))  {
    //        Debug.Log("Ground hit");
    //        inputManager.OnGroundHit();
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
         if (collision.collider.gameObject.tag == "Floor" && anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))  {
            Debug.Log("Ground hit");
            inputManager.OnGroundHit();
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Tunnel Entrance")  {

    //        if (inTunnel == true)
    //        {
    //            inTunnel = false;
    //            cam.ZoomOut();
    //        } else {
    //            inTunnel = true;
    //            cam.ZoomIn();
    //        }
    //    }
        
    //    if (other.gameObject.tag == "Floor" && anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") == true) {
    //        anim.SetTrigger("StopJump");
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.tag == "Floor")  {
    //        Debug.Log("Grounded");
    //        rb.velocity = Vector3.zero;
    //        rb.angularVelocity = Vector3.zero;
    //    }
    //}
}
