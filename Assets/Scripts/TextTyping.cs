using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KoreanTyper;
using TMPro;

public class TextTyping : MonoBehaviour
{
    public TMP_Text message;
    public List<string> originText;

    private void Start()
    {
        StartCoroutine(TypingRoutine());
    }

    IEnumerator TypingRoutine()
    {
        message.text = "";
        for (int t = 0; t < originText.Count; t++)
        {
            int strTypingLength = originText[t].GetTypingLength();

            for (int i = 0; i <= strTypingLength; i++)
            {
                message.text = originText[t].Typing(i);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
        }
    }
}
