using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject playerPrefab;

    public float survivalTime;
    public float levelgameTime = 10f;
    public bool isGameWin;
    public bool isGameOver;

    public enum GAMESTATION : int
    {
        MENU,
        SELECTLEVEL,
        LEVEL1 = 10,
        LEVEL2,
        LEVEL3,
        LEVEL4,
        LEVEL5,
        END = 100
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Application.targetFrameRate = 60;
    }

    public void StartGame()
    {
        if (!isGameOver)
        {
            if (!isGameWin)
            {
                LevelStart.instance.timeText.text = "Time: " + (int)survivalTime;
                if (survivalTime <= 0)
                {
                    Win();
                }
                survivalTime -= Time.deltaTime;
            }
        }
        else
        {
            Loss();
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void Win()
    {
        LevelStart.instance.gamewinPanel.SetActive(true);
        PlayerController.instance.Live();
    }

    public void Loss()
    {
        LevelStart.instance.gameoverPanel.SetActive(true);
        PlayerController.instance.Die();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
