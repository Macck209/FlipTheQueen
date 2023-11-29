using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float walkSpeed=10;

    [SerializeField] int jumpForce = 30, fallModifier = 100, dashForce = 30;

    Rigidbody2D rb;
    bool isGrounded = true;

    bool ableToDash = false;
    bool isDashing = false;
    Vector2 dashVector = Vector2.zero;
    Vector2 dashDir = Vector2.zero;
    float dashTime = 0.0f;

    private Vector2 Vector2Dir(Vector2 vec)
    {
        if (vec.x > 0.0f)
            vec.x = 1;
        else if (vec.x < 0.0f)
            vec.x = -1;

        if (vec.y > 0.0f)
            vec.y = 1;
        else if (vec.y < 0.0f)
            vec.y = -1;
        return vec;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position,new Vector2(1f,0.2f),0,groundLayer);

        dashTime += Time.deltaTime;
        if(dashTime >= 0.5f)
        {
            dashVector *= 1.0f - (0.75f * Time.deltaTime);
            if (dashVector.x == 0.0f && dashVector.y == 0.0f)
                dashDir = Vector2.zero;
        }

        if (isGrounded)
        {
            if(Input.GetButtonDown("Jump"))
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            ableToDash = false;
            isDashing = false;
            dashVector = Vector2.zero;
            dashDir = Vector2.zero;
            dashTime = 0.0f;
        }
        else if(!isDashing)
        {
            if(!ableToDash && Input.GetButtonUp("Jump"))
            {
                ableToDash = true;
            }
            else if(ableToDash && Input.GetButtonDown("Jump"))
            {
                isDashing = true;
                dashVector = new Vector2(dashForce, dashForce);
                dashDir = Vector2Dir(new Vector2(Input.GetAxis("Horizontal"), Mathf.Max(Input.GetAxis("Vertical"), 0)));
                if (dashDir.x == 0 && dashDir.y == 0)
                    dashDir.y = 1;

                rb.velocity = new Vector2(dashVector.x, dashVector.y * (5/3)) * dashDir + new Vector2(0,dashForce/3);
            }
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity -= new Vector2(0, fallModifier * Time.fixedDeltaTime);
        }

        float horizontalVelocity = (isDashing && dashDir.x != 0) ? dashVector.x * dashDir.x : Input.GetAxis("Horizontal") * walkSpeed;

        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDashing)
        {
            dashVector.x *= -1.0f;
            rb.velocity *= new Vector2(-1,1);
            rb.velocity += new Vector2(0,20.0f);
        }
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheck.position, new Vector3(1f,0.2f,0));
    }
    */
}