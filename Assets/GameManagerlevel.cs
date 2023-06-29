
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerlevel : MonoBehaviour
{
    public GameObject player;
    public GameObject winCollider;
    public GameObject loseCollider;
    public float timerDuration = 60f;
    public TMP_Text timerText;
    
    public GameObject WinCanvas;
    public GameObject LoseCanvas;

    private bool hasWon;
    private bool hasLost;
    private bool timerStarted;
    private float timer;

    private void Start()
    {
        hasWon = false;
        hasLost = false;
        timerStarted = false;
        timer = timerDuration;
        UpdateTimerDisplay();
    }

    private void Update()
    {
        // Start the timer when the player moves
        if (!timerStarted && player.GetComponent<Rigidbody2D>().velocity.magnitude > 0f)
        {
            timerStarted = true;
        }

        // Update the timer countdown
        if (timerStarted && !hasWon && !hasLost)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                LoseGame();
            }

            UpdateTimerDisplay();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == winCollider && !hasWon)
        {
            WinGame();
        }
        else if (other == loseCollider && !hasLost)
        {
            LoseGame();
        }
    }

    private void WinGame()
    {
        hasWon = true;
        Debug.Log("You Win!");
        WinCanvas.SetActive(true);

        // Add any win-related logic here
    }

    private void LoseGame()
    {
        hasLost = true;
        Debug.Log("You Lose!");
        LoseCanvas.SetActive(true);

        // Add any lose-related logic here
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timerString;
    }
}
