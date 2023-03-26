using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump Details")]
    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedJump;

    [Header("Ground Details")]
    [SerializeField] private Transform groundcheck;
    [SerializeField] private float circleRad;
    [SerializeField] private LayerMask ground;
    public bool grounded;

    [Header("Components")]
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimeCounter = jumpTime;
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position,circleRad,ground);

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            stoppedJump = false;
        }

        if (Input.GetButton("Jump") && !stoppedJump && (jumpTimeCounter > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            stoppedJump = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundcheck.position, circleRad);
    }
}
