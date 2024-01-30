using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelSystem : MonoBehaviour
{
    public static SelectLevelSystem instance;

    public Button[] levelButton;
    public Sprite[] levelSprite;
    public Sprite[] selectedlevelSprites;
    public GameObject buttons;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        Init();
    }

    private void Start()
    {
        for(int i = 0; i < levelButton.Length; i++)
        {
            if (levelButton[i].CompareTag("Lock"))
            {
                ChangeButtonImage(levelButton[i], levelSprite[0], selectedlevelSprites[0]);
            }
            else if (levelButton[i].CompareTag("Open"))
            {
                ChangeButtonImage(levelButton[i], levelSprite[1], selectedlevelSprites[1]);
            }
            else if (levelButton[i].CompareTag("Clear"))
            {
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

    private void Init()
    {
        levelButton = buttons.GetComponentsInChildren<Button>();

        for (int i = 0; i < levelButton.Length; i++)
        {
            levelButton[i].tag = "Lock";
            ChangeButtonImage(levelButton[i], levelSprite[0], selectedlevelSprites[0]);
        }

        levelButton[2].tag = "Open";
    }
}
