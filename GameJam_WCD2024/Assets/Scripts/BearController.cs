using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        FollowTarget();
    }

    public void FollowTarget()
    {
        if (target.GetComponent<HoneyController>().isGrounded)
        {
            if (target.transform.position.x > transform.position.x)
                rig.velocity = new Vector2(1 * 5, rig.velocity.y);
            if (target.transform.position.x < transform.position.x)
                rig.velocity = new Vector2(-1 * 5, rig.velocity.y);

            GetComponent<Collider2D>().excludeLayers = LayerMask.GetMask("Default");
        }
    }
}
