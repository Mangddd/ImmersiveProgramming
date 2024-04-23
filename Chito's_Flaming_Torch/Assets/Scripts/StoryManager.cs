using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class StoryManager : MonoBehaviour
{
    public Image characterImage; // 캐릭터 이미지를 표시할 Image UI 요소
    public TMP_Text storyText; // 스토리 텍스트를 표시할 Text UI 요소
    public Image mapImage;
    public Button nextButton; // 다음으로 진행할 버튼

    public Sprite[] characterSprites; // 각 스토리 단계별로 사용할 캐릭터 이미지 배열
    public string[] storyMessages; // 각 스토리 단계별로 사용할 텍스트 배열

    private int currentStoryIndex = 0; // 현재 스토리 인덱스


    void Start()
    {
        nextButton.gameObject.SetActive(false);
        // 시작할 때 첫 번째 스토리 단계를 표시합니다.
        if (characterSprites.Length > 0 && storyMessages.Length > 0)
        {
            characterImage.sprite = characterSprites[0];
            storyText.text = storyMessages[0];
        }

    }

    // 스토리 진행 함수
    public void ProgressStory()
    {

        // 다음 스토리 단계로 진행
        currentStoryIndex++;
        // 현재 스토리 인덱스가 배열 범위를 벗어나면 종료
        if (currentStoryIndex >= storyMessages.Length)
        {
            // 추가적인 처리나 다음 동작을 여기에 추가할 수 있습니다.
            Debug.Log("스토리 끝!");
            // 버튼 활성화 여부 결정 (마지막 스토리 단계에서는 버튼 비활성화)
            nextButton.gameObject.SetActive(true);

            return;
        }

        // 캐릭터 이미지 변경
        if (currentStoryIndex < characterSprites.Length)
        {
            characterImage.sprite = characterSprites[currentStoryIndex];
        }

        // 텍스트 변경
        storyText.text = storyMessages[currentStoryIndex];

        // 지도 표시 여부 결정 (마지막 스토리 단계에서는 지도를 표시)
        mapImage.gameObject.SetActive(true);

    }

    // 다음으로 진행할 버튼 클릭 시 호출되는 함수
    public void OnNextButtonClick()
    {
        nextButton.gameObject.SetActive(false);
        mapImage.gameObject.SetActive(false);
    }
}
