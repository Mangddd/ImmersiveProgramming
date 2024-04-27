using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager2 : MonoBehaviour
{
    public Image[] heads; // UI 이미지 배열, 이름을 'heads'에서 'heads'로 유지
    private int currentHead = 0; // 현재 채워진 이미지 인덱스
    public Button NextButton; // 게임 재시작 버튼

    // 오브젝트가 터치될 때 호출되는 메서드
    public void UpdateHearts()
    {
         
        if (currentHead < heads.Length)
        {
            heads[currentHead].color = Color.white; // 이미지 색상 변경
            currentHead++; // 다음 이미지로 이동
            Debug.Log(""+currentHead);
        }
        if (currentHead == 5)
        {
            NextButton.gameObject.SetActive(true); // 게임 재시작 버튼 활성화
            currentHead = 0;
        }
    }


}