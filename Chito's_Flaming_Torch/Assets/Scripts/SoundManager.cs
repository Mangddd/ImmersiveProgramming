using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource BGMSource;
    private float defaultVolume = 0.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        // ������ ����� ���� ���� �ִ��� Ȯ���ϰ� ����
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume");
            SetMusicVolume(savedVolume);
        }
        else
        {
            // �⺻ ���� ����
            SetMusicVolume(defaultVolume);
        }
    }

    public void SetMusicVolume(float volume)
    {
        BGMSource.volume = volume;
        // ���� ���� PlayerPrefs�� ����
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
