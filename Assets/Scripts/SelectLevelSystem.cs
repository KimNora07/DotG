using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SelectLevelSystem : MonoBehaviour
{
    public static SelectLevelSystem instance;

    private static bool shouldExecuteOnSceneReload = true;

    public Button[] levelButton;
    public Sprite[] levelSprite;
    public Sprite[] selectedlevelSprites;
    public GameObject buttons;

    public TMP_Text[] text;

    int textCount = 0;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        if(shouldExecuteOnSceneReload)
        {
            GameManager.Instance.levelIndex = 0;
            shouldExecuteOnSceneReload = false;
        }
        Init();
    }

    private void Start()
    {
        for(int i = 0; i < levelButton.Length; i++)
        {
            levelButton[GameManager.Instance.levelIndex].tag = "Open";
            if (i < GameManager.Instance.levelIndex)
            {
                levelButton[i].tag = "Clear";
            }
            if (levelButton[i].CompareTag("Lock"))
            {
                levelButton[i].onClick.AddListener(Lock);
                ChangeButtonImage(levelButton[i], levelSprite[0], selectedlevelSprites[0]);
            }
            else if (levelButton[i].CompareTag("Open"))
            {
                levelButton[i].onClick.AddListener(Open);
                ChangeButtonImage(levelButton[i], levelSprite[1], selectedlevelSprites[1]);
            }
            else if (levelButton[i].CompareTag("Clear"))
            {
                levelButton[i].onClick.AddListener(Clear);
                ChangeButtonImage(levelButton[i], levelSprite[2], selectedlevelSprites[2]);
            }
        }
    }

    public void ChangeButtonImage(Button button, Sprite normalSprite, Sprite selectedSprites)
    {
        Image buttonImage = button.GetComponent<Image>();

        if (buttonImage != null)
        {
            buttonImage.sprite = normalSprite;

            SpriteState spriteState = button.spriteState;
            spriteState.selectedSprite = selectedSprites;
            button.spriteState = spriteState;
        }
        else
        {
            Debug.LogError("이미지를 설정할 수 없습니다.");
        }
    }

    public void Init()
    {
        levelButton = buttons.GetComponentsInChildren<Button>();

        for (int i = 0; i < levelButton.Length; i++)
        {
            levelButton[i].tag = "Lock";
            ChangeButtonImage(levelButton[i], levelSprite[0], selectedlevelSprites[0]);
        }

        levelButton[GameManager.Instance.levelIndex].tag = "Open";
    }

    private void Lock()
    {
        textCount = 0;
        StartCoroutine(Fade(true));
        Debug.Log("이 단계는 잠겨있습니다! 전 단계를 클리어하시면 열립니다.");
    }

    private void Open()
    {
        SceneManager.LoadScene("DotG");
        Debug.Log("단계가 열림");
    }

    private void Clear()
    {
        textCount = 1;
        StartCoroutine(Fade(true));
        Debug.Log("이미 클리어한 단계입니다!");
    }

    private IEnumerator Fade(bool isFadeIn)
    {
        if (isFadeIn)
        {
            text[textCount].alpha = 0;
            Tween tween = text[textCount].DOFade(1f, 0.25f);
            yield return tween.WaitForCompletion();
            StartCoroutine(Fade(false));
        }
        else
        {
            text[textCount].alpha = 1;
            text[textCount].gameObject.SetActive(true);
            Tween tween = text[textCount].DOFade(0f, 0.25f);
            yield return tween.WaitForCompletion();
        }
    }


}
