using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject optionsCanvas;
    public GameObject creditsCanvas;
    public GameObject loadingScreen;
    public GameObject optionsoptionsScreen;

    public void Awake()
    {
        
            optionsCanvas.SetActive(false);
            creditsCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);
            loadingScreen.SetActive(false);
    }

    public void PlayNextLevel()
    {
        // Load the next scene using the build index
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void ShowOptions()
    {
        mainMenuCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }
    public void ShowCredits()
    {
        mainMenuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }
    public void Backfromoptions()
    {
        mainMenuCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
    }
    public void Backfromcredits()
    {
        mainMenuCanvas.SetActive(true);
        creditsCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
