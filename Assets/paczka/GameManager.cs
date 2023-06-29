using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject loadingScreen; // Reference to the loading screen UI element
    public GameObject mainMenucanvas;
    public Slider progressBar; // Reference to the progress bar UI element

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // Show the loading screen
        mainMenucanvas.SetActive(false);
        loadingScreen.SetActive(true);

        // Start loading the scene asynchronously
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        // Prevent the scene from automatically activating
        asyncOperation.allowSceneActivation = false;

        // Update the progress bar while loading
        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f); // Normalize the progress between 0 and 1
            progressBar.value = progress;

            // Check if the loading is complete (90% progress)
            if (asyncOperation.progress >= 0.9f)
            {
                // Hide the loading screen
                loadingScreen.SetActive(false);

                // Allow the scene activation to complete
                asyncOperation.allowSceneActivation = true;
            }

            yield return new WaitForSeconds(5);

            yield return null;
        }
    }
}
