using UnityEngine;

public class InteractableController : MonoBehaviour
{
    [HideInInspector]
    public bool interacted = false;

    [SerializeField]
    private string function;

    void Update()
    {
        if (interacted)
            Interacted(function);
    }

    void Interacted(string function)
    {
        switch (function)
        {
            case "House":
                GameManager.instance.levelDone = true;
                GameManager.instance.NextLevel();
                break;
            case "Food":
                GameManager.instance.needsFood--;
                Destroy(gameObject);
                break;
            case "Water":
                GameManager.instance.needsWater--;
                gameObject.GetComponent<Collider2D>().enabled = false;
                interacted = false;
                break;
            case "Herb":
                if (gameObject.tag != "Death")
                {
                    GameManager.instance.needsHerb--;
                    Destroy(gameObject);
                }
                else
                    GameManager.instance.Death("Herb");
                break;
            case "Campfire":
                GameManager.instance.needsCampfire--;
                Destroy(gameObject);
                break;
            case "Bridge":
                TreeFalling();
                break;
            case "Honey":
                HoneyFalling();
                break;
        }
    }

    void TreeFalling()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Fall", true);
        gameObject.layer = 6;
    }

    void HoneyFalling()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        FixedJoint2D fixJoint = GetComponent<FixedJoint2D>();
        fixJoint.enabled = false;
    }
}
