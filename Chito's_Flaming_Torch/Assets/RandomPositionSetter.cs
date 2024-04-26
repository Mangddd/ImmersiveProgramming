using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionSetter : MonoBehaviour
{
    public float radius = 5.0f; // ������Ʈ�� ��ġ�� �� �ִ� �ݰ�
    private Vector3 basePosition; // �ʱ� �߽� ��ġ

    void Start()
    {
        // ���� ��ġ ����
        Vector3 randomPosition = Random.insideUnitSphere * radius;
        randomPosition.y = 0; // ������Ʈ�� ���� ���� ��ġ�ϵ��� Y ��ǥ ����
        transform.position = randomPosition; // ���� ���� ��ġ�� ������Ʈ �̵�
        basePosition = transform.position; // �������� ���������� ����� �ʱ� ��ġ ����
    }
}