using UnityEngine;

public class InteractableController : MonoBehaviour
{
    [HideInInspector]
    public bool interacted = false;

    [SerializeField]
    private string function;

    void Update()
    {
        if(interacted)
            Interacted(function);
    }

    void Interacted(string function)
    {
        switch(function)
        {
            case "Food":
                GameManager.instance.needsFood --;
                break;
            case "Water":
                GameManager.instance.needsWater --;
                break;
            case "Herb":
                GameManager.instance.needsHerb --;
                break;
            case "Campfire":
                GameManager.instance.needsCampfire --;
                break;
            case "Bridge":
                
                break;
            case "Honey":
            
                break;
        }
        
        gameObject.GetComponent<Collider2D>().enabled = false;
        interacted = false;
    }

    
}
