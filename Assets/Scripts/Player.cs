using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform respawnPoint;
    private InputManager inputManager;
    private Rigidbody rb;
    private float distanceToGround;
    public bool inTunnel;
    private Animator anim;
    public float gravityModifier;
    public bool respawning;
    public bool testInteract;
    
    void Awake() {
        inputManager = GetComponent<InputManager>();
        rb = GetComponent<Rigidbody>();
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
        anim = GetComponent<Animator>();
    }

    public void Respawn() {
        respawning = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        inputManager.state = InputManager.State.Idle;
        anim.SetTrigger("Die");
    }
    
    public void RespawnHelper() {
        rb.position = respawnPoint.position;
        
        if (this.GetType() == typeof(AdultPlayer)) {
            FindObjectOfType<ScoreManager>().AdultDied();
        } else {
            FindObjectOfType<ScoreManager>().ChildDied();
        }

        respawning = false;
    }
    
    public bool IsGrounded() {
        //Debug.DrawLine(transform.position, transform.position - Vector3.up * (distanceToGround + 1f), Color.green);
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.5f) && anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") == false;
        //return anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") == false;
    }

    private void FixedUpdate()
    {
        rb.AddForce(rb.mass * Physics.gravity * gravityModifier, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
       //Debug.Log("OnCollisionEnter " + collision.collider.gameObject.name);
         if (collision.collider.gameObject.tag == "Floor" && inputManager.onGround == false)  {
           //Debug.Log("Ground hit");
            inputManager.OnGroundHit();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DeathFloor>() != null && respawning == false) {
            Respawn();
        }
    }

}
