using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandVehicleMover : MonoBehaviour {

    public float EffectiveSpeed { get; private set; }

    /// <summary>
    /// Speed in m/s.
    /// </summary>
    public float Speed = 1;

    /// <summary>
    /// Current heading.
    /// </summary>
    public Vector3 Heading = Vector3.zero;

    private Rigidbody rigidbody_;

	// Use this for initialization
	void Start () {
        rigidbody_ = GetComponent<Rigidbody>();
	}

    private float change = .5f;
    private float t = 0;

	// Update is called once per frame
	void FixedUpdate () {

        if (t > change) {
            //Vector3 newHeading = new Vector3(Random.value, 0, Random.value); //x, y, z - y is height, z is axis towards default camera
            //transform.forward = Vector3.RotateTowards(transform.forward, newHeading, Vector3.SignedAngle(transform.forward, newHeading, Vector3.up), Mathf.PI);
            EffectiveSpeed = 2 * Random.value * Speed;
            t = 0;
        }
        t += Time.deltaTime;
        rigidbody_.MovePosition(transform.position + EffectiveSpeed * transform.forward * Time.deltaTime);
	}
}
