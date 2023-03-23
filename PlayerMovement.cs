using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator myAnimator;

    private bool facingRight = true;

    public float speed = 2.0f;
    public float horizMovement;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizMovement = Input.GetAxisRaw("Horizontal"); //GetAxis
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(horizMovement * speed, rb2D.velocity.y);
        FacingDirection(horizMovement);
        myAnimator.SetFloat("speed",Mathf.Abs(horizMovement));
    }

    private void FacingDirection(float horizontal)
    {
        if (horizontal < 0 && facingRight ||  horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight;

            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }
    }
}
