using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image[] heads; // UI �̹��� �迭, �̸��� 'heads'���� 'heads'�� ����
    private int currentHead = 0; // ���� ä���� �̹��� �ε���
    public Button NextButton; // ���� ����� ��ư

    void Start()
    {
        NextButton.gameObject.SetActive(false); // ���� �� ��ư ��Ȱ��ȭ
    }

    // ������Ʈ�� ��ġ�� �� ȣ��Ǵ� �޼���
    public void UpdateHearts()
    {
        if (currentHead < heads.Length)
        {
            heads[currentHead].color = Color.white; // �̹��� ���� ����
            currentHead++; // ���� �̹����� �̵�
        }
        if (currentHead ==3){
                            
             NextButton.gameObject.SetActive(true); // ���� ����� ��ư Ȱ��ȭ
            currentHead = 0;
        }
    }
    

}