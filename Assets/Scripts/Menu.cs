using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button StartButton;
    public Button OptionButton;
    public Button ExitButton;
    public Button BackButton;

    public GameObject menuPanel;
    public GameObject optionPanel;

    public bool isOption;

    [SerializeField] private GameObject[] _menuList;
    [SerializeField] private Button[] _firstSelectButton;
    [SerializeField] private Slider[] _firstSelectSlider;
    [SerializeField] private int _Menuindex = 0;
    [SerializeField] private int _Buttonindex = 0;
    [SerializeField] private int _Sliderindex = -1;

    private void Start()
    {
        isOption = false;
        StartButton.onClick.AddListener(ClickStart);
        OptionButton.onClick.AddListener(ClickOption);
        ExitButton.onClick.AddListener(ClickExit);
        BackButton.onClick.AddListener(ClickBack);
        SelectedMenu(_Menuindex, _Buttonindex, _Sliderindex);
    }

    private void ClickStart()
    {
        StartCoroutine(WaitForSecond());
        SceneManager.LoadScene("SelectLevel");
    }

    private void ClickOption()
    {
        if(isOption == false)
        {
            isOption = true;
            _Menuindex = 1;
            _Buttonindex = 3;
            _Sliderindex = -1;
            StartCoroutine(WaitForSecond());
        }
    }

    private void ClickExit()
    {
        Debug.Log("°ÔÀÓÁ¾·áµÊ");
        Application.Quit();
    }

    private void ClickBack()
    {
        if(isOption == true)
        {
            isOption = false;
            _Menuindex = 0;
            _Buttonindex = 0;
            _Sliderindex = -1;
            StartCoroutine(WaitForSecond());
        }
    }

    public void SelectedMenu(int MenuIndex, int ButtonIndex, int SliderIndex)
    {
        foreach (GameObject menu in _menuList)
        {
            menu.SetActive(false);
        }
        _menuList[MenuIndex].SetActive(true);
        if (_Buttonindex >= 0)
            _firstSelectButton[ButtonIndex].Select();
        if (_Sliderindex >= 0)
        {
            _firstSelectSlider[SliderIndex].Select();
        }
    }

    IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(.3f);
        SelectedMenu(_Menuindex, _Buttonindex, _Sliderindex);
    }
}
