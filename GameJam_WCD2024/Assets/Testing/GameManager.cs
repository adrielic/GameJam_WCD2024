using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int needsFood, needsWater, needsHerb, needsCampfire;
    [SerializeField]
    private GameObject houseObj;

    [SerializeField]
    private float curTime, maxTimeInMinutes;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(Timer(maxTimeInMinutes));
    }

    void Update()
    {
        Debug.Log(needsFood + ", " + needsWater + ", " + needsHerb + ", " + needsCampfire);

        if (needsFood <= 0 && needsWater <= 0 && needsHerb <= 0 && needsCampfire <= 0)
            houseObj.GetComponent<Collider2D>().enabled = true;
    }

    IEnumerator Timer(float maxTime)
    {
        while (true)
        {
            if (curTime > maxTime * 60)
                Debug.Log("Acabou o tempo");

            yield return new WaitForSeconds(1);

            curTime++;
        }
    }
}
