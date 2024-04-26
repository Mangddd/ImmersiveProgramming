using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionMoving : MonoBehaviour
{
    public float radius = 5.0f; // ������Ʈ�� ��ġ�� �� �ִ� �ݰ�
    public float amplitude = 1.0f; // �¿� �������� ����
    public float frequency = 1.0f; // �¿� �������� ���ļ�
    private Vector3 basePosition; // �ʱ� �߽� ��ġ

    void Start()
    {
        // ���� ��ġ ����
        Vector3 randomPosition = Random.insideUnitSphere * radius;
        randomPosition.y = 0; // ������Ʈ�� ���� ���� ��ġ�ϵ��� Y ��ǥ ����
        transform.position = randomPosition; // ���� ���� ��ġ�� ������Ʈ �̵�
        basePosition = transform.position; // �������� ���������� ����� �ʱ� ��ġ ����
    }

    void Update()
    {
        // �¿� ������: ���� �Լ��� ���
        float movement = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = basePosition + new Vector3(movement, 0, 0); // �ʱ� ��ġ�� �������� �¿�� ������
    }
}
