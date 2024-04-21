using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyController : MonoBehaviour
{
    [HideInInspector]
    public bool isGrounded = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
            isGrounded = true;
    }
}
