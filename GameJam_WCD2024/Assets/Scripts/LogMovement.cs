using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed, timeUntilInvert;
    private bool onWater;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(InvertDirection(timeUntilInvert));
    }

    // Update is called once per frame
    void Update()
    {
        if (onWater)
            rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    IEnumerator InvertDirection(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            speed *= -1;
        }
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
