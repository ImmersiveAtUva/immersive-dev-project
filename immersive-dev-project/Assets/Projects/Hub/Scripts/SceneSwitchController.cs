using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Immersive.Hub {
    /// <summary>
    /// Controls switching between scenes
    /// </summary>
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
            FadeController.instance.FadeOutCompletedEvent += SwitchScenes;
        }
        
        /// <summary>
        /// Begin the transition of changing scenes
        /// </summary>
        /// <param name="nextScene"> the local location of the SceneAsset to load in</param>
        public void TeleportTo(string nextScene) {
            // TODO: check if file exists or is a SceneAsset
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