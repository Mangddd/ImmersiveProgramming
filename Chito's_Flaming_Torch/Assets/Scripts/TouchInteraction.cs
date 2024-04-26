using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TouchInteraction : MonoBehaviour
{
    public UIManager uiManager;       // UI 매니저 참조
    public AudioManager audioManager; // AudioManager 참조
    public TimerUIManager timerUIManager; // TimerUIManager 참조
    public TextMeshProUGUI timerText; // TextMeshProUGUI 타입
    public Button nextButton; // 다음 레벨로 넘어갈 버튼
    public Button restartButton; // 게임 재시작 버튼

    private int touchedObjectsCount = 0;  // 터치된 오브젝트 수
    private bool gameEnded = false; // 게임 종료 여부

    void Start()
    {
        // 시작 시 버튼들 비활성화
        nextButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

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
                            timerUIManager?.ObjectTouched();
                            touchedObjectsCount++;

                            Debug.Log("touchedObjectsCount : " + touchedObjectsCount);
                            // 게임 승리 조건 체크
                            if (touchedObjectsCount == 3)
                            {
                                Debug.Log("All objects touched, game won!");
                                GameEnd(true); // 성공 시 다음 레벨로 넘어가는 버튼만 활성화
                            }

                            gameObject.SetActive(false); // 오브젝트 비활성화
                        }
                    }
                }
            }
            else
            {
                // 시간이 다 되었을 때
                GameEnd(false); // 실패 시 게임 재시작 버튼만 활성화
            }
        }
    }

    // 게임의 종료 조건을 처리하는 메서드
    private void GameEnd(bool success)
    {
       

        if (success)
        {
            nextButton.gameObject.SetActive(true); // 다음 레벨로 넘어가는 버튼 활성화
        }
        else
        {
            restartButton.gameObject.SetActive(true); // 게임 재시작 버튼 활성화
        }
        
        timerUIManager.enabled = false; // 타이머 UI 매니저 비활성화
    }
}
