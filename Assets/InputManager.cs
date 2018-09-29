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
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        
        if (Mathf.Abs(x) < xErrorThresh) {
            x = 0f;
        }
        
        if (Mathf.Abs(y) < yErrorThresh) {
            y = 0f;
        }
        
        if (Input.GetKeyUp(KeyCode.JoystickButton1) == true && player.IsGrounded() == true) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
	}

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (new Vector3(x, 0f, 0f)) * Time.deltaTime * movementSpeed);
        rb.MovePosition(rb.position + (new Vector3(0f, 0f, y)) * Time.deltaTime * movementSpeed);
    }
}
