using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 

public class TimerManager : MonoBehaviour
{
    public float timeLeft = 20.0f; // ���� �ð�
    public TextMeshProUGUI timerText; // TextMeshProUGUI Ÿ������ ����
    public TimerUIManager timerUIManager; // TimerUIManager ����

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
        }
    }

    private void CheckGameOver()
    {
        if (timerUIManager.ObjectsTouched < 5)
        {
            Debug.Log("Time up! Game over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���� �����
        }
    }
}
