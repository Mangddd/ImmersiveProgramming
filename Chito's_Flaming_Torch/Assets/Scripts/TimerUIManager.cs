using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUIManager : MonoBehaviour
{
    private int totalObjects = 5; // ��ü ��ġ�ؾ� �� ������Ʈ ��
    private int objectsTouched = 0; // ������� ��ġ�� ������Ʈ ��
    public float timeLeft = 30.0f; // ���� �ð�

    void Update()
    {
        timeLeft -= Time.deltaTime; // �ð� ���Ҵ� Update() �޼��忡�� ó���Ǿ�� �մϴ�.
    }

    // ������Ʈ�� ��ġ�� �� ȣ��Ǵ� �޼���
    public void ObjectTouched()
    {
        objectsTouched++;
        if (objectsTouched >= totalObjects)
        {
            Debug.Log("All objects touched, game won!");
            // ���� �¸� ó��, ���⼭ �߰����� �¸� ������ ������ �� �ֽ��ϴ�.
        }
    }

    public int ObjectsTouched { get { return objectsTouched; } }  // �ܺο��� ���� ������ ������Ƽ
}
