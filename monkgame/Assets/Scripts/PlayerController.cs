using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 30f;
	public float maxSpeed = 5f;
	public float jumpPower = 100f;
	public GameObject interactableObject;
	public AnimalType animalType = AnimalType.TYPE_NONE;
	public Transform groundTransform;
	private bool isGrounded = false;
	private bool hasJumped = false;
	private bool fallDeath = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = Physics2D.Linecast (transform.position, groundTransform.position, 1 << LayerMask.NameToLayer("Ground"));

		if(Input.GetButtonDown("Jump"))
		{
			UsePower ();
		}

		if(Input.GetAxis("Vertical") > 0)
		{
			Interact();
		}
	}

	void FixedUpdate(){
		float h = Input.GetAxis("Horizontal");
		
		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
			rigidbody2D.AddForce(Vector2.right * h * speed);
		
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

	public void UsePower()
	{
		if(animalType == AnimalType.TYPE_NONE)
		{
			// Nothing at all
		}
		else if(animalType == AnimalType.TYPE_CAT)
		{
			Jump();
		}
		else if(animalType == AnimalType.TYPE_MOUSE)
		{
		}
		else if(animalType == AnimalType.TYPE_FISH)
		{
		}
		else if(animalType == AnimalType.TYPE_BIRD)
		{
		}
	}

	public void Jump()
	{
		if(isGrounded)
			hasJumped = true;
	}

	public void Interact()
	{
		if(interactableObject != null)
		{
			animalType = interactableObject.GetComponent<AnimalController>().animalType;
			fallDeath = interactableObject.GetComponent<AnimalController>().fallDeath;
			speed = interactableObject.GetComponent<AnimalController>().speed;
			maxSpeed = interactableObject.GetComponent<AnimalController>().maxSpeed;
			jumpPower = interactableObject.GetComponent<AnimalController>().jumpPower;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "LivingObject")
		{
			interactableObject = other.gameObject;
		}

		if(other.name == "deathground" && fallDeath == true)
		{
			print ("you dead");
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "LivingObject")
		{
			interactableObject = null;
		}
	}
}
