using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager2 : MonoBehaviour
{
    public Image[] heads; // UI �̹��� �迭, �̸��� 'heads'���� 'heads'�� ����
    private int currentHead = 0; // ���� ä���� �̹��� �ε���
    public Button NextButton; // ���� ����� ��ư

    // ������Ʈ�� ��ġ�� �� ȣ��Ǵ� �޼���
    public void UpdateHearts()
    {
       
        NextButton.gameObject.SetActive(false); 
        if (currentHead < heads.Length)
        {
            heads[currentHead].color = Color.white; // �̹��� ���� ����
            currentHead++; // ���� �̹����� �̵�
            Debug.Log(""+currentHead);
        }
        if (currentHead == 5)
        {
            NextButton.gameObject.SetActive(true); // ���� ����� ��ư Ȱ��ȭ
            currentHead = 0;
        }
    }


}