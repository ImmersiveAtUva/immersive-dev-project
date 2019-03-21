using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

    private bool triggerPulled = false;
    //public Scene nextScene;
    public string nextScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        triggerPulled = Input.GetButton("Right Trigger");
	}

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Handheld.Vibrate();
            print(collision.gameObject.name);
            if (triggerPulled && nextScene != null)
            {
                print("Trigger Pressed");
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
