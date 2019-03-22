using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;

public class Movement : MonoBehaviour {

    public Vector3 lastPosition;
    public GameObject playerRig;
    public float multiplier = 1;
    public float threshold = 0.2f;
    public float upperThreshold = 10;
    public float currentSpeed = 0;
    public float lastSpeed;

    public float delayTime = 3f;

    public TrackedPoseDriver tp;

    // Use this for initialization
    void Start () {
        lastPosition = transform.localPosition;
        lastSpeed = 0;
    }

    // Update is called once per frame
    void Update () {
        if (delayTime > 0)
        {
            delayTime -= Time.deltaTime;
            if (delayTime <= 0) delayTime = 0;
        }
        else
        {

            Vector3 velocity = (transform.localPosition - lastPosition) / Time.deltaTime;
            print(velocity);
            if (Mathf.Abs(velocity.y) > threshold)
            {
                currentSpeed = Mathf.Min(upperThreshold,multiplier * Mathf.Abs(velocity.y) * Time.deltaTime);
                playerRig.transform.Translate(Vector3.forward* Mathf.Lerp(lastSpeed, currentSpeed, Time.deltaTime));
                lastSpeed = currentSpeed;
            }
            lastPosition = transform.localPosition;
        }
    }
}
