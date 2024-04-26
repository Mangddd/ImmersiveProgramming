using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (audioSource.clip != null)
            audioSource.Play();
    }
}
