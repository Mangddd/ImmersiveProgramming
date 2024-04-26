using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TouchInteraction : MonoBehaviour
{
    public UIManager uiManager;       // UI �Ŵ��� ����
    public UIManager2 uiManager2;       // UI �Ŵ��� ����
    public AudioManager audioManager; // AudioManager ����
    public TimerUIManager timerUIManager; // TimerUIManager ����
    public TextMeshProUGUI timerText; // TextMeshProUGUI Ÿ��
 
    private int touchedObjectsCount = 0;  // ��ġ�� ������Ʈ ��
    private bool gameEnded = false; // ���� ���� ����

   

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
                            uiManager2?.UpdateHearts();
                            timerUIManager?.ObjectTouched();
                            

                            gameObject.SetActive(false); // ������Ʈ ��Ȱ��ȭ
                        }
                    }
                }
            }
           
        }
    }

  
}
