using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotator : MonoBehaviour {

    public string FrontRightName;
    public string FrontLeftName;
    public string BackRightName;
    public string BackLeftName;

    private LandVehicleMover mover_;
    private Transform frontRight_;
    private Transform frontLeft_;
    private Transform backRight_;
    private Transform backLeft_;

    private float circumference_ = 1;

    // Use this for initialization
    void Start() {
        mover_ = GetComponent<LandVehicleMover>();
        frontRight_ = transform.Find(FrontRightName);
        backLeft_ = transform.Find(BackLeftName);
        backRight_ = transform.Find(BackRightName);
        frontLeft_ = transform.Find(FrontLeftName);

        // Assuming all the wheels are the same size, get the approximate radius
        var mesh = frontRight_.gameObject.GetComponent<Renderer>().bounds.size;
        circumference_ = 2 * Mathf.PI * mesh.y/2;
    }

    // Update is called once per frame
    void Update() {

        // Get distance vehicle has traveled since last update
        float d = mover_.EffectiveSpeed * Time.deltaTime;

        // Get the fraction of rotations (in degrees) to cover distance d
        float rotations = 360 * d / circumference_;

        // Rotate wheels based on vehicle speed
        if (frontRight_ != null) {
            frontRight_.Rotate(Vector3.right, rotations);
        }
        if (frontLeft_ != null) {
            frontLeft_.Rotate(Vector3.right, rotations);
        }
        if (backRight_ != null) {
            backRight_.Rotate(Vector3.right, rotations);
        }
        if (backLeft_ != null) {
            backLeft_.Rotate(Vector3.right, rotations);
        }

    }
}
