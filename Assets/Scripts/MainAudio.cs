using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudio : MonoBehaviour {
    private AudioSource audioSource;
    private void Start() {
        DontDestroyOnLoad(gameObject);
        audioSource.Play();
    }
}
