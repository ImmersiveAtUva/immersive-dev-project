using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Immersive.Hub {
    public class SceneSwitchController : MonoBehaviour {

        public static SceneSwitchController instance;

        public string nextSceneName;

        void Awake() {
            if(instance != null) {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // Use this for initialization
        void Start() {
            FadeController.instance.FadedOutEvent += SwitchScenes;
        }
        
        public void TeleportTo(string nextScene) {
            nextSceneName = nextScene;
            FadeController.instance.FadeOut();
        }

        public void SwitchScenes() {
            SceneManager.LoadScene(nextSceneName);
            nextSceneName = "";
            FadeController.instance.FadeIn();
        }
    }
}