using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject buttons, credits, text;

    public void ReturnToMenu()
    {
        LevelLoader.instance.LoadScene("First");
    }

    public void Credits()
    {
        buttons.SetActive(false);
        text.SetActive(false);
        credits.SetActive(true);
    }

    public void Back()
    {
        buttons.SetActive(true);
        text.SetActive(true);
        credits.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
