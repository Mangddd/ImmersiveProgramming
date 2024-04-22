using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class StoryManager : MonoBehaviour
{
    public Image characterImage; // ĳ���� �̹����� ǥ���� Image UI ���
    public TMP_Text storyText; // ���丮 �ؽ�Ʈ�� ǥ���� Text UI ���

    public Sprite[] characterSprites; // �� ���丮 �ܰ躰�� ����� ĳ���� �̹��� �迭
    public string[] storyMessages; // �� ���丮 �ܰ躰�� ����� �ؽ�Ʈ �迭

    private int currentStoryIndex = 0; // ���� ���丮 �ε���


    void Start()
    {
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
        // ���� ���丮 �ܰ�� ����
        currentStoryIndex++;

        // ���� ���丮 �ε����� �迭 ������ ����� ����
        if (currentStoryIndex >= storyMessages.Length)
        {
            Debug.Log("���丮 ��!");
            return;
        }

        // ĳ���� �̹��� ����
        if (currentStoryIndex < characterSprites.Length)
        {
            characterImage.sprite = characterSprites[currentStoryIndex];
        }

        // �ؽ�Ʈ ����
        storyText.text = storyMessages[currentStoryIndex];
    }
}