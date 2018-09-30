using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public float x, y, rotX, rotY;
    public float movementSpeed;
    public float xErrorThresh, yErrorThresh;
    public float jumpForce;
    public float turnSpeed;

    private Rigidbody rb;
    private Player player;
    private Animator anim;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (player.GetType() == typeof(AdultPlayer)) {
            x = Input.GetAxis("Player1Horizontal");
            y = Input.GetAxis("Player1Vertical");

            rotX = Input.GetAxis("Player1CameraHorizontal");
            rotY = -Input.GetAxis("Player1CameraVertical"); // this one is inverted

            //Debug.Log("rotX = " + rotX + " rotY = " + rotY);
            //Debug.Log("IsGrounded = " + player.IsGrounded());

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") == false && Input.GetButtonUp("Player1Jump") == true && player.IsGrounded() == true) {
                Debug.Log("Adult player jumping");
           
                anim.SetTrigger("Jump");
            }   
        } else if (player.GetType() == typeof(ChildPlayer)) {
            x = Input.GetAxis("Player2Horizontal");
            y = Input.GetAxis("Player2Vertical");

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") == false && Input.GetButtonUp("Player2Jump") == true && player.IsGrounded() == true) {
                Debug.Log("Child player jumping");
                anim.SetTrigger("Jump");
            }
        }
        
        if (Mathf.Abs(x) < xErrorThresh) {
            x = 0f;
        }
        
        if (Mathf.Abs(y) < yErrorThresh) {
            y = 0f;
        }
        
       
	}
    
    public void Jump() {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    
    }
    
    public void PauseJumpAnimation() {
        anim.speed = 0f;
    }
    
    public void OnGroundHit() {
        anim.speed = 1f;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (new Vector3(x, 0f, 0f)) * Time.deltaTime * movementSpeed);
        rb.MovePosition(rb.position + (new Vector3(0f, 0f, y)) * Time.deltaTime * movementSpeed);

        var turnRatio = rotX / 1f * turnSpeed;
        

        var deltaRotation = Quaternion.Euler(new Vector3(0f, turnRatio, 0f) * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
