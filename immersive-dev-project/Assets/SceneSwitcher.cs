using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

    private bool triggerPulled = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        triggerPulled = Input.GetButton("Right Trigger");
	}

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Portal")
        {
            print(collision.gameObject.name);
            if (triggerPulled)
            {
                print("Trigger Pressed");
                SceneManager.LoadScene("Recursive");
            }
        }
    }
}
