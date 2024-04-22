// SettingSceneScript.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolManager : MonoBehaviour
{
    GameObject bgmSource;
    AudioSource bgm;
    public Slider volumeSlider;

    void Start()
    {
        bgmSource = GameObject.Find("BGMSource");
        bgm = bgmSource.GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("volumeSlider"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("volumeSlider");
            Debug.Log("get vol: " + volumeSlider.value);
        }
        else
        {
            volumeSlider.value = 0.5f;
        }
    }

    public void ChangeVol()
    {
        bgm.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("volumeSlider", volumeSlider.value);
        Debug.Log("set vol: " + volumeSlider.value);
    }

}
