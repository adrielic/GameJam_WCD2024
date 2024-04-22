using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource soundFxPlayer;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PlaySoundClip(AudioClip audioClip, Transform spawnPoint, float volume)
    {
        AudioSource audioSource = Instantiate(soundFxPlayer, spawnPoint);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
