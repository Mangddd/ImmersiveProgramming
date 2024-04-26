using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TouchInteraction : MonoBehaviour
{
    public UIManager uiManager;       // UI �Ŵ��� ����
    public AudioManager audioManager; // AudioManager ����
    public TimerUIManager timerUIManager; // TimerUIManager ����
    public TextMeshProUGUI timerText; // TextMeshProUGUI Ÿ��
    public Button nextButton; // ���� ������ �Ѿ ��ư
    public Button restartButton; // ���� ����� ��ư

    private int touchedObjectsCount = 0;  // ��ġ�� ������Ʈ ��
    private bool gameEnded = false; // ���� ���� ����

    void Start()
    {
        // ���� �� ��ư�� ��Ȱ��ȭ
        nextButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!gameEnded)
        {
            // �ð��� ���� ���Ҵٸ�
            if (timerUIManager.timeLeft > 0)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                    {
                        Ray ray = Camera.main.ScreenPointToRay(touch.position);
                        RaycastHit hit;
                        
                        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
                        {
                            // ������Ʈ�� ��ġ�Ǿ��� �� ������ �ڵ�
                            audioManager?.PlaySound();
                            uiManager?.UpdateHearts();
                            timerUIManager?.ObjectTouched();
                            touchedObjectsCount++;

                            Debug.Log("touchedObjectsCount : " + touchedObjectsCount);
                            // ���� �¸� ���� üũ
                            if (touchedObjectsCount == 3)
                            {
                                Debug.Log("All objects touched, game won!");
                                GameEnd(true); // ���� �� ���� ������ �Ѿ�� ��ư�� Ȱ��ȭ
                            }

                            gameObject.SetActive(false); // ������Ʈ ��Ȱ��ȭ
                        }
                    }
                }
            }
            else
            {
                // �ð��� �� �Ǿ��� ��
                GameEnd(false); // ���� �� ���� ����� ��ư�� Ȱ��ȭ
            }
        }
    }

    // ������ ���� ������ ó���ϴ� �޼���
    private void GameEnd(bool success)
    {
       

        if (success)
        {
            nextButton.gameObject.SetActive(true); // ���� ������ �Ѿ�� ��ư Ȱ��ȭ
        }
        else
        {
            restartButton.gameObject.SetActive(true); // ���� ����� ��ư Ȱ��ȭ
        }
        
      
    }
}
