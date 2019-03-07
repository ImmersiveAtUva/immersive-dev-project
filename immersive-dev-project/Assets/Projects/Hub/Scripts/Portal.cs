using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Immersive.Hub {
    public class Portal : MonoBehaviour {

        public string nextSceneName;

        private bool triggerPulled = false;

        // Update is called once per frame
        void Update() {
            triggerPulled = Input.GetButton("Right Trigger");

            if (Input.GetButton("Jump")) {
                SceneSwitchController.instance.TeleportTo(nextSceneName);
            }
        }

        private void OnTriggerStay(Collider collision) {
            if (collision.gameObject.tag == "Portal") {
                print(collision.gameObject.name);
                if (triggerPulled) {
                    print("Trigger Pressed");
                    SceneSwitchController.instance.TeleportTo(nextSceneName);
                }
            }
        }
    }
}
