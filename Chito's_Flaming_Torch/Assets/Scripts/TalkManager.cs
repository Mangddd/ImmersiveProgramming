using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class TalkManager : MonoBehaviour
{
    public TMP_Text Message;
    public Sprite[] sprites;
    private int clickCount = 0;

    private void Start()
    {
        UpdateCharacterAndMessage();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickCount++;
            UpdateCharacterAndMessage();
        }
    }

    private void UpdateCharacterAndMessage()
    {
        switch (clickCount)
        {
            case 0:
                SetCharacterAndMessage(sprites[0], "Hi! I'm Chito. Nice to meet you!");
                break;
            case 1:
                SetCharacterAndMessage(sprites[1], "Hmm...Where's my friend Torch?\nI think he's hiding out on the campus of the Ajou University.");
                break;
            case 2:
                Message.text = "Can you help me find my friend?";
                break;
            default:
                clickCount = 0; // Reset clickCount if it exceeds the defined cases
                SetCharacterAndMessage(sprites[0], "Hi! I'm Chito. Nice to meet you!");
                break;
        }
    }

    private void SetCharacterAndMessage(Sprite sprite, string message)
    {
        GameObject.Find("Character").GetComponent<Image>().sprite = sprite;
        Message.text = message;
    }
}
