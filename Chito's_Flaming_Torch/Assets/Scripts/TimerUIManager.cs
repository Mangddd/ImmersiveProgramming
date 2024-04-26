using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUIManager : MonoBehaviour
{
    private int totalObjects = 5; // 전체 터치해야 할 오브젝트 수
    private int objectsTouched = 0; // 현재까지 터치된 오브젝트 수
    public float timeLeft = 30.0f; // 제한 시간

    void Update()
    {
        timeLeft -= Time.deltaTime; // 시간 감소는 Update() 메서드에서 처리되어야 합니다.
    }

    // 오브젝트가 터치될 때 호출되는 메서드
    public void ObjectTouched()
    {
        objectsTouched++;
        if (objectsTouched == totalObjects)
        {
            Debug.Log("All objects touched, game won!");
            // 게임 승리 처리, 여기서 추가적인 승리 로직을 구현할 수 있습니다
        }
    }

    public int ObjectsTouched { get { return objectsTouched; } }  // 외부에서 접근 가능한 프로퍼티
}
