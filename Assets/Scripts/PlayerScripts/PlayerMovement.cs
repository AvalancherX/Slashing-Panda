using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f, jumpForce = 20f;

    private Rigidbody2D rb;
    private Transform groundCheckPos;
    [SerializeField] private LayerMask groundLayer;
    private bool canDoubleJump = false;
    private PlayerAnimationsWithTransition playerAnim;
    [SerializeField] private float attackWaitTime = 0.5f;
    private float attackTimer;
    private bool canAttack;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheckPos = transform.GetChild(0).transform;
        playerAnim = GetComponent<PlayerAnimationsWithTransition>();
    }
    void Start()
    {
        
    }

    private void Update()
    {
        PlayerJump();
        AnimatePlayer();
        GetAttackInput();
        HandleAttack();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
    }

    private void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown(TagManager.JUMP_BUTTON))
        {
            if(!isGrounded() && canDoubleJump)
            {
                canDoubleJump = false;
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                playerAnim.PlayDoubleJump();
            }
            if(isGrounded())
            {
                canDoubleJump = true;
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }

    }

    private void AnimatePlayer()
    {
        playerAnim.PlayJump(rb.velocity.y);
        playerAnim.PlayFromJumpToRunning(isGrounded());
    }

    private void GetAttackInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(Time.time > attackTimer)
            {
                attackTimer = Time.time + attackWaitTime;
                canAttack = true;
            }
        }
    }

    private void HandleAttack()
    {
        if(canAttack && isGrounded())
        {
            playerAnim.PlayAttack();
            canAttack = false;
        }
        else if(canAttack && !isGrounded())
        {
            canAttack = false;
            playerAnim.PlayJumpAttack();
        }

    }
}
