using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public float x, y;
    public float movementSpeed;
    public float xErrorThresh, yErrorThresh;
    public float jumpForce;
    private Rigidbody rb;
    private Player player;
    
    
    void Awake() {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (player.GetType() == typeof(AdultPlayer)) {
            x = Input.GetAxis("Player1Horizontal");
            y = Input.GetAxis("Player1Vertical");
            
            if (Input.GetButtonUp("Player1Jump") == true && player.IsGrounded() == true) {
                Debug.Log("Adult player jumping");
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }   
        } else if (player.GetType() == typeof(ChildPlayer)) {
            x = Input.GetAxis("Player2Horizontal");
            y = Input.GetAxis("Player2Vertical");
            
            if (Input.GetButtonUp("Player2Jump") == true && player.IsGrounded() == true) {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                Debug.Log("Child player jumping");
            }
        }
        
        if (Mathf.Abs(x) < xErrorThresh) {
            x = 0f;
        }
        
        if (Mathf.Abs(y) < yErrorThresh) {
            y = 0f;
        }
        
       
	}

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (new Vector3(x, 0f, 0f)) * Time.deltaTime * movementSpeed);
        rb.MovePosition(rb.position + (new Vector3(0f, 0f, y)) * Time.deltaTime * movementSpeed);
    }
}
