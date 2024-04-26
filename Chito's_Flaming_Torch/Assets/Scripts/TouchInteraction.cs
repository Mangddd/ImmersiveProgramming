using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TouchInteraction : MonoBehaviour
{
    public UIManager uiManager;       // UI 매니저 참조
    public UIManager2 uiManager2;       // UI 매니저 참조
    public AudioManager audioManager; // AudioManager 참조
    public TimerUIManager timerUIManager; // TimerUIManager 참조
    public TextMeshProUGUI timerText; // TextMeshProUGUI 타입
 
    private int touchedObjectsCount = 0;  // 터치된 오브젝트 수
    private bool gameEnded = false; // 게임 종료 여부

   

    void Update()
    {
        if (!gameEnded)
        {
            // 시간이 아직 남았다면
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
                            // 오브젝트가 터치되었을 때 실행할 코드
                            audioManager?.PlaySound();
                            uiManager?.UpdateHearts();
                            uiManager2?.UpdateHearts();
                            timerUIManager?.ObjectTouched();
                            

                            gameObject.SetActive(false); // 오브젝트 비활성화
                        }
                    }
                }
            }
           
        }
    }

  
}
