using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class StoryManager : MonoBehaviour
{
    public Image characterImage; // ĳ���� �̹����� ǥ���� Image UI ���
    public TMP_Text storyText; // ���丮 �ؽ�Ʈ�� ǥ���� Text UI ���
    public Image mapImage;
    public Button nextButton; // �������� ������ ��ư

    public Sprite[] characterSprites; // �� ���丮 �ܰ躰�� ����� ĳ���� �̹��� �迭
    public string[] storyMessages;

    private int currentStoryIndex = 0; // ���� ���丮 �ε���


    void Start()
    {
        nextButton.gameObject.SetActive(false);
        // ������ �� ù ��° ���丮 �ܰ踦 ǥ���մϴ�.
        if (characterSprites.Length > 0 && storyMessages.Length > 0)
        {
            characterImage.sprite = characterSprites[0];
            storyText.text = storyMessages[0];
        }

    }

    // ���丮 ���� �Լ�
    public void ProgressStory()
    {
        currentStoryIndex++;

        // ���� ���丮 �ε����� �迭 ������ ����� ����
        if (currentStoryIndex >= storyMessages.Length)
        {
            //Debug.Log("���丮 ��!");
            // ��ư Ȱ��ȭ ���� ���� (������ ���丮 �ܰ迡���� ��ư ��Ȱ��ȭ)
            nextButton.gameObject.SetActive(true);
            return;
        }

        // ĳ���� �̹��� ����
        if (currentStoryIndex < characterSprites.Length)
        {
            characterImage.sprite = characterSprites[currentStoryIndex];
        }

        // �ؽ�Ʈ ����
        storyText.text = storyMessages[currentStoryIndex];

        // ���� ǥ�� ���� ���� (������ ���丮 �ܰ迡���� ������ ǥ��)
        mapImage.gameObject.SetActive(true);

    }

    // �������� ������ ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnNextButtonClick()
    {
        nextButton.gameObject.SetActive(false);
        mapImage.gameObject.SetActive(false);
    }
}
