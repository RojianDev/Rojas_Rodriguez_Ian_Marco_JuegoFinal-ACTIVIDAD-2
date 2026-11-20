using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject WinnerUI;
    [SerializeField] OguriController player;
    private bool isGameOver = false;

    void Awake()
    {
        if(Instance == null)
        {
            Instance =  this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    public void PlayerLose()
    {
        if(isGameOver) return;

        isGameOver = true;
        gameOverUI.SetActive(true);
        player.canMove = false;
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Winner()
    {
        if(isGameOver) return;

        isGameOver = true;
        WinnerUI.SetActive(true);
        player.canMove = false;
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        
    }
}
