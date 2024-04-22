using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayerManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip gameMusic;
    public AudioClip menuMusic;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        
        SceneManager.sceneLoaded += OnSceneLoaded; 

        PlayGameMusic();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0 || scene.buildIndex == 8)
        {
            PlayMenuMusic();
        }
        else
        {
            PlayGameMusic();
        }
    }

    private void PlayGameMusic()
    {
        if (audioSource.clip != gameMusic || !audioSource.isPlaying)
        {
            audioSource.clip = gameMusic;
            audioSource.Play();
        }
    }

    private void PlayMenuMusic()
    {
        if (audioSource.clip != menuMusic || !audioSource.isPlaying)
        {
            audioSource.clip = menuMusic;
            audioSource.Play();
        }
    }
}
