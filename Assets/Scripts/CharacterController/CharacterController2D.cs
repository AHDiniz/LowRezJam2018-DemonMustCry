using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
	public float speed;
	public float jumpForce;
	public float jumpDuration;
	public float groundCheckRadius;
	public Transform groundChecker;
	public LayerMask groundLayer;
	public AudioClip[] playerSFX;

	private bool isGrounded;
	private bool isJumping;
	private float moveInput;
	private float jumpTimeCounter;
	private Rigidbody2D rigidBody2D;
	private SpriteRenderer spriteRenderer;
	private Animator animator;
	private AudioSource audioSource;

	private void Start()
	{
		rigidBody2D = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		jumpTimeCounter = jumpDuration;
	}

	private void Update()
	{
		VerticalMovement();
	}

	private void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckRadius, groundLayer);
		animator.SetBool("isGrounded", isGrounded);
		animator.SetBool("isJumping", isJumping);
		HorizontalMovement();
	}

	private void HorizontalMovement()
	{
        moveInput = Input.GetAxisRaw("Horizontal");
		if (moveInput != 0 && isGrounded)
			animator.SetBool("isRunning", true);
		else
            animator.SetBool("isRunning", false);
        rigidBody2D.velocity = new Vector2(moveInput * speed, rigidBody2D.velocity.y);
		if (moveInput < 0)
			spriteRenderer.flipX = true;
		else if (moveInput > 0)
			spriteRenderer.flipX = false;
	}
	
	private void VerticalMovement()
	{
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			isJumping = true;
			audioSource.clip = playerSFX[0];
			audioSource.loop = false;
			audioSource.Play();
			jumpTimeCounter = jumpDuration;
			rigidBody2D.velocity = Vector2.up * jumpForce;
		}

		if (Input.GetButton("Jump") && isJumping)
		{
			if (jumpTimeCounter > 0)
			{
                rigidBody2D.velocity = Vector2.up * jumpForce;
				jumpTimeCounter -= Time.deltaTime;
			}
			else
				isJumping = false;
		}

		if (Input.GetButtonUp("Jump"))
			isJumping = false;
	}
}
