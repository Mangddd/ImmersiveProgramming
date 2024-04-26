using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public float timeLeft = 30.0f; // ���� �ð�
    public TextMeshProUGUI timerText; // TextMeshProUGUI Ÿ��
    public TimerUIManager timerUIManager; // TimerUIManager ����
    public Button restartButton; // ���� ����� ��ư

    void Start()
    {
        restartButton.gameObject.SetActive(false); // ���� �� ��ư ��Ȱ��ȭ
    }

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
        restartButton.gameObject.SetActive(true); // ���� ����� ��ư Ȱ��ȭ
    }
}
