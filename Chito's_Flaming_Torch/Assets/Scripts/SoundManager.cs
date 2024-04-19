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

        // 이전에 저장된 볼륨 값이 있는지 확인하고 적용
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume");
            SetMusicVolume(savedVolume);
        }
        else
        {
            // 기본 볼륨 설정
            SetMusicVolume(defaultVolume);
        }
    }

    public void SetMusicVolume(float volume)
    {
        BGMSource.volume = volume;
        // 볼륨 값을 PlayerPrefs에 저장
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
