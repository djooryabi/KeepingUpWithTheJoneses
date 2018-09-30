using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	public GameObject player;       //Public variable to store a reference to the player game object
    public Vector3 normalOffset;         //Private variable to store the offset distance between the player and camera
    public Vector3 tunnelOffset;
    public Vector3 currentOffset;
    
    // Use this for initialization
    void Start () 
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        //normalOffset = transform.position - player.transform.position;
        //currentOffset = normalOffset;
        //tunnelOffset = new Vector3(0f, 10.86f, -29.35f);
        currentOffset = normalOffset;
    }
    
    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + currentOffset;
        transform.LookAt(player.transform.position, Vector3.up);
    }
    
    public void ZoomIn() {
        currentOffset = tunnelOffset;
    }
    
    public void ZoomOut() {
        currentOffset = normalOffset;
    }
}
