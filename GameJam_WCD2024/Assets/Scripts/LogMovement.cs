using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed, dirX, initPosX;
    private bool onWater;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        initPosX = transform.position.x;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (transform.position.x < initPosX - 5.5f)
            dirX = 1;
        if (transform.position.x > initPosX + 5.5f)
            dirX = -1;

        if (onWater)
            rb.velocity = new Vector2(speed * dirX, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 4)
            onWater = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 4)
            onWater = false;
    }
}
