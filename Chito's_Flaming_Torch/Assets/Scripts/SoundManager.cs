using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGMSource;

    // Start is called before the first frame update
    public void SetMusicVolume(float volume)
    {
        BGMSource.volume = volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
