using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour {

    Rigidbody rb;
    Vector3 lastPosition;

    public GameObject collided;
    float freedTime;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Left Trigger"))
        {
            if (collided != null && Time.time > freedTime)
            {

                collided.transform.SetParent(this.transform);
                collided.GetComponent<Rigidbody>().isKinematic = true;
                collided.transform.localPosition = Vector3.zero;
            } else
            {
                foreach (Transform child in transform)
                {
                    Rigidbody childRB = child.GetComponent<Rigidbody>();
                    Vector3 velocity = (transform.position - lastPosition) / Time.deltaTime;
                    childRB.isKinematic = false;
                    child.transform.SetParent(null);
                    //childRB.velocity = velocity;
                    childRB.AddForce(velocity);
                    print(string.Format("velocity {0}, Magnitude {1}", velocity, velocity.magnitude));
                    freedTime = Time.time + 2;
                }
            }

        }
        lastPosition = transform.position;
	}

    void OnCollisionEnter(Collision collision)
    {
        //print("Hello I collided");
        collided = collision.gameObject;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collided == collision.gameObject)
            collided = null;
    }


}
