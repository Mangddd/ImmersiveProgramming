using UnityEngine;

public class TouchInteraction : MonoBehaviour
{
    public UIManager uiManager;       // UI 매니저 참조
    public AudioManager audioManager; // AudioManager 참조
    public TimerUIManager timerUIManager; // TimerUIManager 참조

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log("Touch detected at position: " + touch.position);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                Debug.Log("Raycasting from camera at position: " + touch.position);
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
                    // 오브젝트가 이 스크립트가 부착된 GameObject일 경우
                    if (hit.collider.gameObject == gameObject)
                    {
                        Debug.Log("Touched object matches this script's object: " + gameObject.name);

                        // 오브젝트가 터치되었을 때 실행할 코드
                        if (audioManager != null)
                        {
                            audioManager.PlaySound();  // AudioManager를 통한 사운드 재생
                            Debug.Log("Playing sound on: " + gameObject.name);
                        }
                        if (uiManager != null)
                        {
                            uiManager.UpdateHearts();  // UI 업데이트 호출
                        }
                        if (timerUIManager != null)
                        {
                            timerUIManager.ObjectTouched();  // TimerUIManager에 터치 알림
                            CheckGameStatus();
                        }

                        gameObject.SetActive(false);  // GameObject를 비활성화하여 사라지게 함
                        Debug.Log("Deactivating object: " + gameObject.name);
                    }
                }
                else
                {
                    Debug.Log("No hit detected");
                }
            }
        }
    }

    // 게임의 승리 또는 패배 상태를 검사합니다.
    private void CheckGameStatus()
    {
        if (timerUIManager.ObjectsTouched >= 5)
        {
            // 승리 조건이 충족될 때의 추가 처리를 여기에 작성할 수 있습니다.
            Debug.Log("All objects touched, game won!");
        }
    }
}
