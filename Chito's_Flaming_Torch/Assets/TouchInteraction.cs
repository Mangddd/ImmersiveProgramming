using UnityEngine;

public class TouchInteraction : MonoBehaviour
{
    public UIManager uiManager;       // UI �Ŵ��� ����
    public AudioManager audioManager; // AudioManager ����
    public TimerUIManager timerUIManager; // TimerUIManager ����

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
                    // ������Ʈ�� �� ��ũ��Ʈ�� ������ GameObject�� ���
                    if (hit.collider.gameObject == gameObject)
                    {
                        Debug.Log("Touched object matches this script's object: " + gameObject.name);

                        // ������Ʈ�� ��ġ�Ǿ��� �� ������ �ڵ�
                        if (audioManager != null)
                        {
                            audioManager.PlaySound();  // AudioManager�� ���� ���� ���
                            Debug.Log("Playing sound on: " + gameObject.name);
                        }
                        if (uiManager != null)
                        {
                            uiManager.UpdateHearts();  // UI ������Ʈ ȣ��
                        }
                        if (timerUIManager != null)
                        {
                            timerUIManager.ObjectTouched();  // TimerUIManager�� ��ġ �˸�
                            CheckGameStatus();
                        }

                        gameObject.SetActive(false);  // GameObject�� ��Ȱ��ȭ�Ͽ� ������� ��
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

    // ������ �¸� �Ǵ� �й� ���¸� �˻��մϴ�.
    private void CheckGameStatus()
    {
        if (timerUIManager.ObjectsTouched >= 5)
        {
            // �¸� ������ ������ ���� �߰� ó���� ���⿡ �ۼ��� �� �ֽ��ϴ�.
            Debug.Log("All objects touched, game won!");
        }
    }
}
