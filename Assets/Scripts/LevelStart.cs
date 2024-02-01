using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelStart : MonoBehaviour
{
    public static LevelStart instance;

    public GameObject gamewinPanel;
    public GameObject gameoverPanel;
    public TMP_Text timeText;
    public GameObject[] levels;
    public int[] levelsTime;
    public Button nextButton;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameManager.Instance.levelgameTime = levelsTime[GameManager.Instance.levelIndex];
        GameManager.Instance.survivalTime = GameManager.Instance.levelgameTime;
        nextButton.onClick.AddListener(Next);
        GameManager.Instance.isGameWin = false;
        GameManager.Instance.isGameOver = false;

        gamewinPanel.SetActive(false);
        gameoverPanel.SetActive(false);

        for(int i = 0; i < levels.Length; i++)
        {
            if (i == GameManager.Instance.levelIndex)
            {
                levels[GameManager.Instance.levelIndex].gameObject.SetActive(true);
            }
            else
            {
                levels[i].gameObject.SetActive(false);
            }
        }
        
    }

    private void Update()
    {
        GameManager.Instance.StartGame();
    }

    public void Next()
    {
        SceneManager.LoadScene("SelectLevel");
    }
}
