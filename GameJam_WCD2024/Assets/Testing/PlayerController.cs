using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private Vector2 direction;
    private int dirLookX;
    [SerializeField] private float moveSpeed, jumpForce;

    private bool isGrounded, isClimbable, jump;

    [SerializeField]
    private LayerMask interactableObjs;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ReadInput();
    }

    void ReadInput()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetButtonDown("Jump") && isGrounded)
            jump = true;

        Interact(Input.GetButtonDown("Interact"));
    }

    void FixedUpdate()
    {
        Move();
        Jump();
        Climb();
    }

    void Move()
    {
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);

        if (direction.x != 0)
        {
            anim.SetBool("Moving", true);
        }
        else
            anim.SetBool("Moving", false);

        if (rb.velocity.x > 0)
            dirLookX = 1;
        if (rb.velocity.x < 0)
            dirLookX = -1;

        Flip(dirLookX);
    }

    void Flip(float dirX)
    {
        if (dirX > 0)
            sr.flipX = false;
        else if (dirX < 0)
            sr.flipX = true;
    }

    void Jump()
    {
        if (jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }

    void Climb()
    {
        if (isClimbable)
        {
            Vector2 climbVelocity = new Vector2(rb.velocity.x, direction.y * moveSpeed);
            rb.velocity = climbVelocity;

            if (direction.y > 0)
                rb.bodyType = RigidbodyType2D.Kinematic;
            else
                rb.bodyType = RigidbodyType2D.Dynamic;

        }
        else
            rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void Interact(bool interact)
    {
        Collider2D verifyCollision = Physics2D.OverlapCircle(transform.position, 1.5f, interactableObjs);

        if (verifyCollision != null)
        {
            if (interact)
            {
                anim.SetTrigger("Interact");

                verifyCollision.GetComponent<InteractableController>().interacted = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.layer)
        {
            case 6:
                isGrounded = true;
                anim.SetBool("Grounded", true);
                break;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        switch (col.gameObject.layer)
        {
            case 6:
                isGrounded = false;
                anim.SetBool("Grounded", false);
                anim.SetTrigger("Jump");
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 7)
        {
            isClimbable = true;
            anim.SetBool("Climbing", true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 7)
        {
            isClimbable = false;
            anim.SetBool("Climbing", false);
        }
    }
}
