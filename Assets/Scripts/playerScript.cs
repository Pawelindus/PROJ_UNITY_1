using System;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    private float horizontal;
    private float speed = 1f;
    private float jumpingPower = 2.5f;
    private bool isFacingRight = true;
    public static int points = 0;
    public static int healthPoints = 3;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private Camera playerCam;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            anim.SetBool(IsJumping, true);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            anim.SetBool(IsJumping, true);
        }

        if (Math.Abs(rb.velocity.y) < 0.1)
        {
            anim.SetBool(IsJumping, false);
        }

        Flip();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            points++;
    
        }
    }

    private void FixedUpdate()
    {
        if (Math.Abs(rb.velocity.x) > 0)
        {
            anim.SetBool(IsMoving, true);
        }
        else
        {
            anim.SetBool(IsMoving, false);
        }

        var pos = new Vector3(transform.position.x, transform.position.y + 0.05f, -10);
        playerCam.transform.position = pos;

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
