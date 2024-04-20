using UnityEngine;

public class GameManager : MonoBehaviour
{    
    public static GameManager instance;
    
    public int needsFood, needsWater, needsHerb, needsCampfire; 

    void Awake() 
    {
        instance = this;
    }

    void Update()
    {
        Debug.Log(needsFood + ", " + needsWater + ", " + needsHerb + ", " + needsCampfire);
        
        if(needsFood <= 0 && needsWater <= 0 && needsHerb <= 0 && needsCampfire <= 0)
            Debug.Log("Terminou");
    }
}
