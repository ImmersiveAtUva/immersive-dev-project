using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void FadeEvent();

/// <summary>
/// Handles Fading in and out
/// </summary>
[RequireComponent(typeof(Animator))]
public class FadeController : MonoBehaviour {

    public static FadeController instance;
    public Animator anim;

    public float speed = 1;
    public Color fadeColor = Color.black;
    public Image fadeImage;

    public FadeEvent FadedOutEvent, FadedInEvent;

    /// <summary>
    /// Whether the fade controller has completely faded out
    /// </summary>
    private bool faded;

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(transform.parent.gameObject);
    }

    void Start() {
        anim = GetComponent<Animator>();
    }

    public void FadeOut() {
        if (faded) return;
        faded = true;
        anim.SetTrigger("Toggle");
    }

    public void FadeIn() {
        if (!faded) return;
        faded = false;
        anim.SetTrigger("Toggle");
    }

    /// <summary>
    /// Method Called by animation event when screen has completely faded to black;
    /// Triggers FadeOut Event
    /// </summary>
    public void HandleFadeOut() {
        FadedOutEvent?.Invoke();
    }

    /// <summary>
    /// Triggered when animation has completely faded in
    /// </summary>
    public void HandleFadedIn() {
        FadedInEvent?.Invoke();
    }
}
