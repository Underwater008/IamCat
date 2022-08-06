using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D hitbox;
    [SerializeField] private LayerMask platformLayerMask;

    private Vector2 accV;
    public bool grounded;

    public float maxV;
    [SerializeField]
    int accel;
    [SerializeField]
    float jumpF;
    [SerializeField]
    float deccel;

    [SerializeField]
    float fallMultiplier = 2.5f;
    [SerializeField]
    float lowJumpMultiplier = 2f;

    public float jumpBufferLength=0.1f;
    private float jumpBufferCount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //walking
        if (Input.GetKey(KeyCode.A))
        {
            accV.x -= accel;
        }
        if (Input.GetKey(KeyCode.D))
        {
            accV.x += accel;
        }
        

        if (!(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)))
        {
            if (rb.velocity.x > 0)
            {
                accV.x -= deccel;
            }
            else if (rb.velocity.x < 0)
            {
                accV.x += deccel;
            }
        }
        //jump buffer
        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpBufferCount = jumpBufferLength;
        }
        else {
            jumpBufferCount -= Time.deltaTime;
        }

        //jumping
        if (jumpBufferCount>=0&&IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpF);
            jumpBufferCount = 0;
        }
        //Extra Gravity
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


        //updateVelocity
        rb.velocity += accV * Time.deltaTime;
        accV = Vector2.zero;
        if (rb.velocity.x >= maxV)
        {
            rb.velocity = new Vector2(maxV, rb.velocity.y);
        }
        if (rb.velocity.x <= -maxV)
        {
            rb.velocity = new Vector2(-maxV, rb.velocity.y);
        }

        //Flip Side when turn
        float horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private bool IsGrounded()
    {
        float extraheight = 0.5f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(hitbox.bounds.center, hitbox.bounds.size, 0f, Vector2.down, extraheight, platformLayerMask);
        return raycastHit.collider != null;
    }
}
