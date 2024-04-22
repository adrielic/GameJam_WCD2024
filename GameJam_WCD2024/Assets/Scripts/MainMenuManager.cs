using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu, credits, musicManager;
    private static bool firstTime = true;

    void Awake()
    {
        if (firstTime)
            Instantiate(musicManager);
    }

    public void Play()
    {
        firstTime = false;
        LevelLoader.instance.LoadSpecificScene(1);
    }

    public void Credits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void Back()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
