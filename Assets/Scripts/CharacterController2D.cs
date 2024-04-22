using System.Collections;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private InputReader inputReader;
	[SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
	[SerializeField] private float jumpTime = 1.0f;
	[Range(0, 1)][SerializeField] private float m_CrouchSpeed = .36f;           // Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;   // How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private float baseGravityScale = 3.0f;
	[SerializeField] private float fallSpeedMultiplier = 7.0f / 3.0f;
	[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching
	[SerializeField] private Collider2D m_WaterCheck;

	public MovementCheck m_GroundCheck;                         // A position marking where to check if the player is grounded.
	public MovementCheck m_CeilingCheck;                            // A position marking where to check for ceilings
	private bool m_Grounded;            // Whether or not the player is grounded.
	private bool isJumping;
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 velocity = Vector3.zero;
	private float currentJumpTime;
	private bool isInWater = false;
	private bool swimLocked = false;
	private float timeInWater = 0f;
	private float swimLockDuration = 0.15f;
	private Camera mainCam;
	public SpriteRenderer gunSprite;


	private void Awake()
	{
		mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

    private void Start()
    {
		inputReader.LookEvent += CheckToFlip;
    }

    private void Update()
	{
		if (m_Rigidbody2D.velocity.y < 0)
		{
			m_Rigidbody2D.gravityScale = baseGravityScale * fallSpeedMultiplier;
		}
		else
		{
			m_Rigidbody2D.gravityScale = baseGravityScale;
		}
		if (isInWater)
		{
			timeInWater += Time.deltaTime;
			float targetDrag = Mathf.Lerp(1, 15, timeInWater / 0.15f);
			m_Rigidbody2D.drag = targetDrag;
			if (timeInWater > swimLockDuration) {
				swimLocked = false;
			}
		}
	}


	private void FixedUpdate()
	{
		m_Grounded = false;

		// The player is grounded if its collider is colliding with the right layer
		if (m_GroundCheck.isColliding)
		{
			m_Grounded = true;
		}
		if (isInWater)
		{
			// Clamp vertical speed
			m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, Mathf.Min(m_Rigidbody2D.velocity.y, 2f));
		}
	}


	public void Move(float move, bool crouch, bool jump)
	{
		if (isInWater)
		{
			move *= 0.5f;
			if (jump && !swimLocked) {
				m_Rigidbody2D.AddForce(new Vector2(0, 200f), ForceMode2D.Force);
			}
		}
		// If crouching, check to see if the character can stand up
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (m_CeilingCheck.isColliding)
			{
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			// If crouching
			if (crouch)
			{
				// Reduce the speed by the crouchSpeed multiplier
				move *= m_CrouchSpeed;

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			} else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);
		}

		float jumpForce = m_JumpForce * m_Rigidbody2D.mass;

		// If the player should jump...
		if (!isInWater && jump && m_Grounded)
		{
			isJumping = true;
			currentJumpTime = jumpTime;
			m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, jumpForce);
		}

		if (jump && isJumping)
		{
			if (currentJumpTime > 0)
			{
				m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 2 * jumpForce);
				currentJumpTime -= Time.deltaTime;
			}
			else
			{
				isJumping = false;
			}
		}

		if (!jump)
		{
			isJumping = false;
		}
    }

	void CheckToFlip(Vector2 mousePosition)
	{
        Vector3 mousePos = mainCam.ScreenToWorldPoint(mousePosition);
        if (mousePos.x<transform.position.x && m_FacingRight)
		{
			Flip();
		}
		else if (mousePos.x > transform.position.x && !m_FacingRight)
		{
			Flip();
		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
        Vector3 gunScale = gunSprite.transform.localScale;
        Vector3 gunPos = gunSprite.transform.localPosition;

        theScale.x *= -1;
        transform.localScale = theScale;

        gunPos.x *= -1;
        gunSprite.transform.localPosition = gunPos;

        gunScale.x *= -1;
        gunScale.y *= -1;
        gunSprite.transform.localScale = gunScale;

        //gunSprite.flipX = !gunSprite.flipX;
        
        
    }
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Water")
		{
			EnterWater();
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Water"))
		{
			if (!m_WaterCheck.IsTouchingLayers(LayerMask.GetMask("Water")))
			{
				ExitWater();
			}
		}
	}

    private void EnterWater()
    {
		Debug.Log("Entered water.");
        isInWater = true;
		swimLocked = true;
		m_Rigidbody2D.AddForce(Vector2.down * 2f, ForceMode2D.Impulse);
		timeInWater = 0;
    }

	private void ExitWater()
	{
		Debug.Log("Exited water.");
		isInWater = false;
		m_Rigidbody2D.drag = 0f;
        m_Rigidbody2D.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
    }



}
