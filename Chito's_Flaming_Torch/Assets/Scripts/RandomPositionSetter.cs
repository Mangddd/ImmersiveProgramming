using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionSetter : MonoBehaviour
{
    public float radius = 5.0f; // 오브젝트가 배치될 수 있는 반경
    private Vector3 basePosition; // 초기 중심 위치

    void Start()
    {
        // 랜덤 위치 설정
        Vector3 randomPosition = Random.insideUnitSphere * radius;
        randomPosition.y = 0; // 오브젝트가 지면 위에 위치하도록 Y 좌표 조정
        transform.position = randomPosition; // 계산된 랜덤 위치로 오브젝트 이동
        basePosition = transform.position; // 움직임의 기준점으로 사용할 초기 위치 저장
    }
}