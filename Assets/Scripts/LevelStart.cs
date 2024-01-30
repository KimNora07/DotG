using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    public static LevelStart instance;

    public GameObject gamewinPanel;
    public GameObject gameoverPanel;
    public TMP_Text timeText;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameManager.Instance.survivalTime = GameManager.Instance.levelgameTime;
        GameManager.Instance.isGameWin = false;
        GameManager.Instance.isGameOver = false;

        gamewinPanel.SetActive(false);
        gameoverPanel.SetActive(false);
    }

    private void Update()
    {
        GameManager.Instance.StartGame();
    }
}
