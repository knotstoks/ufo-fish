using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    [SerializeField] private Image blackScreen;
    public static MainMenu instance;
    private void Start() {
        if (!instance) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        StartCoroutine(FadeOut());
    }
    public void NextSceneButton(string sceneName) {
        Debug.Log("HI");
        StartCoroutine(NextScene(sceneName));
    }
    public IEnumerator NextScene(string sceneName) {
        // Animation for the fade screen
        StartCoroutine(FadeToBlack());
        yield return new WaitForSeconds(1);
        // Go to next scene
        SceneManager.LoadScene(sceneName);
        // Fade up to the scene
        StartCoroutine(FadeOut());
    }
    public IEnumerator FadeToBlack() {
        for (double i = 0; i < 1.04; i += 0.04) {
            blackScreen.color = new Color(0, 0, 0, (float) i);
            yield return new WaitForSeconds(0.03f);
        }
    }
    public IEnumerator FadeOut() {
        for (double i = 0; i < 1.04; i += 0.04) {
            blackScreen.color = new Color(0, 0, 0,  (float) (1 - i));
            yield return new WaitForSeconds(0.04f);
        }
    }
}
