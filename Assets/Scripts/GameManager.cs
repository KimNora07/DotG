using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject playerPrefab;

    public float survivalTime;
    public float levelgameTime = 10f;
    public bool isGameWin;
    public bool isGameOver;

    public float musicVolume;
    public float sfxVolume;

    public int levelIndex;

    public enum GAMESTATION : int
    {
        MENU,
        SELECTLEVEL,
        OPTION,
        LEVEL1 = 10,
        LEVEL2,
        LEVEL3,
        LEVEL4,
        LEVEL5,
        LEVEL6,
        LEVEL7,
        LEVEL8,
        LEVEL9,
        END = 100
    }

    public GAMESTATION gameStation;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        Application.targetFrameRate = 60;
    }

    void OnEnable()
    {
        musicVolume = 1.0f;
        sfxVolume = 1.0f;
    }

    public void StartGame()
    {
        if (!isGameOver)
        {
            if (!isGameWin)
            {
                LevelStart.instance.timeText.text = "남은시간: " + (int)survivalTime;
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
        if(levelIndex < 9 )
        {
            levelIndex += 1;
            levelgameTime += 5f;
        }
    }

    public void Loss()
    {
        LevelStart.instance.gameoverPanel.SetActive(true);
        PlayerController.instance.Die();
    }

    public void Ending()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
