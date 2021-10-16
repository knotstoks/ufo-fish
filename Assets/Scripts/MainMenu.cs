using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    [SerializeField] private Image blackScreen;
    [SerializeField] private GameObject instructionsOne;
    [SerializeField] private GameObject instructionsTwo;
    [SerializeField] private GameObject instructionsThree;
    private void Start() {
        instructionsOne.SetActive(false);
        instructionsTwo.SetActive(false);
        instructionsThree.SetActive(false);
        StartCoroutine(FadeOut());
    }
    public void NextSceneButton(string sceneName) {
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

    public void ShowInstructions() {
        instructionsOne.SetActive(true);
    }

    public void ShowSecondInstruction() {
        instructionsOne.SetActive(false);
        instructionsTwo.SetActive(true);
    }

    public void ShowThirdInstruction() {
        instructionsTwo.SetActive(false);
        instructionsThree.SetActive(true);
    }

    public void BackToMainMenu() {
        instructionsThree.SetActive(false);
    }
}
