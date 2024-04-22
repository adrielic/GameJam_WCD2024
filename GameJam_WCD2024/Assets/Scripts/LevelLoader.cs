using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    [SerializeField] private Animator transitionAnim;
    private int currentSceneIndex;

    void Awake()
    {
        if (instance == null)
            instance = this;

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadScene(string loadType)
    {
        switch (loadType)
        {
            case "Next":
                StartCoroutine(NextScene());
                break;
            case "First":
                StartCoroutine(FirstScene());
                break;
            case "Reload":
                StartCoroutine(ReloadScene());
                break;
        }
    }

    public void LoadSpecificScene(int index)
    {
        StartCoroutine(SpecificScene(index));
    }

    IEnumerator NextScene()
    {
        transitionAnim.SetTrigger("ToSleep");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    IEnumerator FirstScene()
    {
        transitionAnim.SetTrigger("ToFade");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    IEnumerator ReloadScene()
    {
        transitionAnim.SetTrigger("ToFade");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(currentSceneIndex);
    }

    IEnumerator SpecificScene(int index)
    {
        transitionAnim.SetTrigger("ToFade");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(index);
    }
}
