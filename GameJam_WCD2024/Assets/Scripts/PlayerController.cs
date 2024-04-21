using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private Vector2 direction;
    [SerializeField] private float moveSpeed, jumpForce;
    private bool canClimb, justJumped;

    [SerializeField]
    private TextMeshProUGUI interactText;

    [SerializeField]
    private LayerMask interactableObjs, groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ReadInput();

        if (IsGrounded())
            anim.SetBool("Grounded", true);
        else
            anim.SetBool("Grounded", false);
    }

    void ReadInput()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetButtonDown("Jump") && IsGrounded())
            justJumped = true;

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

        Flip(direction.x);
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
        if (justJumped)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            justJumped = false;
        }
    }

    void Climb()
    {
        if (canClimb)
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
            interactText.text = "Pressione 'J' ou 'X' para interagir!";

            if (interact)
            {
                anim.SetTrigger("Interact");

                verifyCollision.GetComponent<InteractableController>().interacted = true;
            }
        }

        else
            interactText.text = null;
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.25f, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * 1.25f, Color.red);

        if (hit.collider != null)
            return true;
        else
            return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 7)
        {
            canClimb = true;
            anim.SetBool("Climbing", true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 7)
        {
            canClimb = false;
            anim.SetBool("Climbing", false);
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Death" && other.gameObject.layer == 4)
            GameManager.instance.Death("Drowned");
        if(other.gameObject.tag == "Death" && other.gameObject.layer == 10)
            GameManager.instance.Death("Bear");
        if(other.gameObject.tag == "Death" && other.gameObject.layer == 11)
            GameManager.instance.Death("Ravine");
    }
}
