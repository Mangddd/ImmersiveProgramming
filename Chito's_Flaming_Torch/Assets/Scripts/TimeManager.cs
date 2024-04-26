using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 

public class TimerManager : MonoBehaviour
{
    public float timeLeft = 20.0f; // 제한 시간
    public TextMeshProUGUI timerText; // TextMeshProUGUI 타입으로 변경
    public TimerUIManager timerUIManager; // TimerUIManager 참조

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "TIME REMAINING: " + Mathf.CeilToInt(timeLeft).ToString() + "s";
        }
        else
        {
            Debug.Log("Time up! Game over!");
           // CheckGameOver();
        }
    }
    /*
    private void CheckGameOver()
    {
        if (timerUIManager.ObjectsTouched < 5)
        {
            Debug.Log("Time up! Game over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 게임 재시작
        }
    }
    */
}
