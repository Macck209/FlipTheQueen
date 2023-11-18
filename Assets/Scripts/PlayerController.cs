using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float walkSpeed=10;

    [SerializeField] int jumpForce = 30, fallModifier = 100;

    Rigidbody2D rb;
    bool isGrounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position,new Vector2(1f,0.2f),0,groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity -= new Vector2(0, fallModifier * Time.fixedDeltaTime);
        }

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * walkSpeed, rb.velocity.y);
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheck.position, new Vector3(1f,0.2f,0));
    }
    */
}