/*
 * Anthony Wessel
 * Assignment 7 - Challenge 4
 * Controls the game state and win/loss conditions
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject WinPanel;
    public GameObject LosePanel;

    public static GameManager Instance;

    public static bool gameInProgress = false;
    public static bool won = false;

    public static void Win()
    {
        won = true;
        gameInProgress = false;
        Instance.WinPanel.SetActive(true);
    }

    public static void Lose()
    {
        won = false;
        gameInProgress = false;
        Instance.LosePanel.SetActive(true);
    }

    public static void StartGame()
    {
        gameInProgress = true;
        Instance.InfoPanel.SetActive(false);
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!gameInProgress)
        {
            if (Input.GetKeyDown(KeyCode.Space)) StartGame();

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
