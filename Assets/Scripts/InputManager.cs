using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public float x, y, rotX, rotY;
    public float movementSpeed;
    public float xErrorThresh, yErrorThresh;
    public float jumpForce;
    public float turnSpeed;
    public bool onGround;

    private Rigidbody rb;
    private Player player;
    private Animator anim;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    private enum State {
        Idle, 
        Walking,
        Jumping
    }

    private State state;
    
	// Update is called once per frame
	void Update () {
        
        if (player.GetType() == typeof(AdultPlayer)) {
            x = Input.GetAxis("Player1Horizontal");
            y = Input.GetAxis("Player1Vertical");

            rotX = Input.GetAxis("Player1CameraHorizontal");
            rotY = -Input.GetAxis("Player1CameraVertical"); // this one is inverted

            //Debug.Log("rotX = " + rotX + " rotY = " + rotY);
            //Debug.Log("IsGrounded = " + player.IsGrounded());

            if (Input.GetButtonUp("Player1Jump") == true && onGround == true) {
                Debug.Log("Adult player jumping");
                onGround = false;
                state = State.Jumping;
                Jump();
                anim.SetTrigger("Jump");
            }   
        } else if (player.GetType() == typeof(ChildPlayer)) {
            x = Input.GetAxis("Player2Horizontal");
            y = Input.GetAxis("Player2Vertical");
            
            rotX = Input.GetAxis("Player2CameraHorizontal");
            rotY = -Input.GetAxis("Player2CameraVertical"); // this one is inverted

            if (Input.GetButtonUp("Player2Jump") == true && onGround == true) {
                Debug.Log("Child player jumping");
                onGround = false;
                state = State.Jumping;
                Jump();
                anim.SetTrigger("Jump");
            }
        }
        
        if (Mathf.Abs(x) < xErrorThresh) {
            x = 0f;
        }
        
        if (Mathf.Abs(y) < yErrorThresh) {
            y = 0f;
        }
        
        if (onGround == true && (Mathf.Abs(y) > 0f) && anim.GetCurrentAnimatorStateInfo(0).IsName("Walking") == false && state != State.Walking) {
            state = State.Walking;
            StartWalking();
        } else if (Mathf.Abs(y) <= 0f && anim.GetCurrentAnimatorStateInfo(0).IsName("Walking") == true && state == State.Walking) {
            state = State.Idle;
            StopWalking();
        }

	}
    
    public void StartWalking() {
    
            Debug.Log("Start walk");

            anim.SetTrigger("Start Walk");
        
    }
    
    public void StopWalking() {
            Debug.Log("Stop walk");
            anim.SetTrigger("Stop Walk");
        
    }
    
    public void Jump() {

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    
    public void PauseJumpAnimation() {
        anim.speed = 0f;
    }
    
    public void OnGroundHit() {
        //anim.speed = 1f;
        onGround = true;
        state = State.Idle;
    }

    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + transform.forward * y * Time.deltaTime * movementSpeed);
        rb.MovePosition(rb.position + transform.right * x * Time.deltaTime * movementSpeed);
        
        

        var turnRatio = rotX / 1f * turnSpeed;
        

        var deltaRotation = Quaternion.Euler(new Vector3(0f, turnRatio, 0f) * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
