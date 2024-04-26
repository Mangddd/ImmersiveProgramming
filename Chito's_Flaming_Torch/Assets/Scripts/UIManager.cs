using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image[] heads; // UI �̹��� �迭, �̸��� 'heads'���� 'heads'�� ����
    private int currentHead = 0; // ���� ä���� �̹��� �ε���

    // ������Ʈ�� ��ġ�� �� ȣ��Ǵ� �޼���
    public void UpdateHearts()
    {
        if (currentHead < heads.Length)
        {
            heads[currentHead].color = Color.white; // �̹��� ���� ����
            currentHead++; // ���� �̹����� �̵�
        }
    }
}