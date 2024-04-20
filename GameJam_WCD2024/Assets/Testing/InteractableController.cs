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
                Debug.Log("Passou de cena");
                break;
            case "Food":
                GameManager.instance.needsFood--;
                gameObject.GetComponent<Collider2D>().enabled = false;
                interacted = false;
                break;
            case "Water":
                GameManager.instance.needsWater--;
                gameObject.GetComponent<Collider2D>().enabled = false;
                interacted = false;
                break;
            case "Herb":
                GameManager.instance.needsHerb--;
                gameObject.GetComponent<Collider2D>().enabled = false;
                interacted = false;
                break;
            case "Campfire":
                GameManager.instance.needsCampfire--;
                gameObject.GetComponent<Collider2D>().enabled = false;
                interacted = false;
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
        FixedJoint2D fixJoint = GetComponent<FixedJoint2D>();
        fixJoint.enabled = false;
    }
}
