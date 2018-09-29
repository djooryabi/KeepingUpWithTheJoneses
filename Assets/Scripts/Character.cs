using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
	public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translationX = Input.GetAxis("Horizontal") * speed;
        //float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        float translationZ = Input.GetAxis("Vertical") * speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translationX *= Time.deltaTime;
        translationZ *= Time.deltaTime;
        //rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(translationX, 0, translationZ);

        // Rotate around our y-axis
        //transform.Rotate(0, rotation, 0);
		Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = rotation;
	}
}
