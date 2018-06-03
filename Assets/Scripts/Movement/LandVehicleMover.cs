using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandVehicleMover : MonoBehaviour {

    /// <summary>
    /// Speed in m/s.
    /// </summary>
    public double speed = 10;

    /// <summary>
    /// Current heading.
    /// </summary>
    public Vector2 heading = Vector2.zero;

    private Rigidbody rigidbody_;
    private Transform transform_;

	// Use this for initialization
	void Start () {
        rigidbody_ = GetComponent<Rigidbody>();
        transform_ = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //rigidbody_.AddForce(new Vector3(1f, 0, 0) * Time.deltaTime);
        //System.Console.WriteLine(rigidbody_.velocity);
        //transform_.position = rigidbody_.velocity;
        rigidbody_.MovePosition(transform_.position + transform_.forward * Time.deltaTime);
	}
}
