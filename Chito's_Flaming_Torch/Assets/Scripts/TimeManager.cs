using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public float timeLeft = 20.0f; // ���� �ð�
    public TextMeshProUGUI timerText; // TextMeshProUGUI Ÿ��
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
            timeLeft = 0; // �ð��� 0���� ������ Ÿ�̸Ӱ� ������ ���� �ʵ��� �մϴ�.
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

    // ������ ���� ������ ó���ϴ� �޼���
    private void GameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}