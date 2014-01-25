using UnityEngine;
using System.Collections;

public class PlatformPlayerController : MonoBehaviour {
	public float walkSpeed = 30.0f;
	public float maxSpeed = 5f;
	public float jumpPower = 1000.0f;
	public Transform groundTransform;

	private bool isGrounded = false;
	private bool hasJumped = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = Physics2D.Linecast (transform.position, groundTransform.position, 1 << LayerMask.NameToLayer("Ground"));
		if(Input.GetButtonDown("Jump"))
		{
			if(isGrounded)
				hasJumped = true;
		}
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
			rigidbody2D.AddForce(Vector2.right * h * walkSpeed);
		
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

		if(hasJumped && isGrounded)
		{
			rigidbody2D.AddForce(new Vector2(0, jumpPower));
			hasJumped = false;
		}
	}
}
