using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isJumping = false;
    private Vector3 characterScale;  // New variable to hold the original scale

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        characterScale = transform.localScale;  // Initialize to the current scale
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        
        if (moveInput > 0)
        {
            characterScale.x = -Mathf.Abs(characterScale.x);
        }
        else if (moveInput < 0)
        {
            characterScale.x = Mathf.Abs(characterScale.x);
        }
        transform.localScale = characterScale;

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
