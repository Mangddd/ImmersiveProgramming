using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public float timeLeft = 20.0f; // 제한 시간
    public TextMeshProUGUI timerText; // TextMeshProUGUI 타입
    public TimerUIManager timerUIManager; // TimerUIManager 참조
    public Button restartButton; // 게임 재시작 버튼

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "TIME REMAINING: " + Mathf.CeilToInt(timeLeft).ToString() + "s";
        }
        else
        {
            CheckGameOver();
            timeLeft = 0; // 시간을 0으로 설정해 타이머가 음수로 가지 않도록 합니다.
        }
    }

    private void CheckGameOver()
    {
        if (timerUIManager.ObjectsTouched < 5)
        {
            Debug.Log("Time up! Game over!");
            GameEnd();
        }
    }

    // 게임의 종료 조건을 처리하는 메서드
    private void GameEnd()
    {

            restartButton.gameObject.SetActive(true); // 게임 재시작 버튼 활성화
    }
}