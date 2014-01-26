using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 30f;
	public float maxSpeed = 5f;
	public float jumpPower = 100f;
	public GameObject interactableObject;
	public AnimalType animalType = AnimalType.TYPE_NONE;
	public Transform groundTransforml;
	public Transform groundTransformr;
	public bool isGroundedL = false;
	public bool isGroundedR = false;
	private bool hasJumped = false;
	private bool fallDeath = true;
	private float scaler;
	public GameObject mouse;
	public GameObject fish;
	public GameObject rabbit;
	public GameObject cat;
	public GameObject bear;
	private Vector3 monkOriginScale;


	// Use this for initialization
	void Start () {
		monkOriginScale = transform.localScale;
	
	}
	
	// Update is called once per frame
	void Update () {
		/* Animal selection inputs
		 * 
		 * 
		 * */
		if(Input.GetButtonDown("mouse")){
			interactableObject = mouse;
			if(animalType != interactableObject.GetComponent<AnimalController>().animalType)
				Interact();

		}

		if(Input.GetButtonDown("fish")){
			interactableObject = fish;
			if(animalType != interactableObject.GetComponent<AnimalController>().animalType)
				Interact();
			
		}

		if(Input.GetButtonDown("rabbit")){
			interactableObject = rabbit;
			if(animalType != interactableObject.GetComponent<AnimalController>().animalType)
				Interact();
			
		}
		if(Input.GetButtonDown("cat")){
			interactableObject = cat;
			if(animalType != interactableObject.GetComponent<AnimalController>().animalType)
				Interact();
			
		}
		if(Input.GetButtonDown("bear")){
			interactableObject = bear;
			if(animalType != interactableObject.GetComponent<AnimalController>().animalType)
				Interact();
			
		}

		


		isGroundedL = Physics2D.Linecast (transform.position, groundTransforml.position, 1 << LayerMask.NameToLayer("Ground"));
		isGroundedR = Physics2D.Linecast (transform.position, groundTransformr.position, 1 << LayerMask.NameToLayer("Ground"));

		if(Input.GetButtonDown("Jump"))
		{
			UsePower ();
		}
		/*
		if(Input.GetAxis("Vertical") > 0)
		{
			Interact();
		}
		*/
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

		if(hasJumped && (isGroundedL || isGroundedR))
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
			Jump();
		}
		else if(animalType == AnimalType.TYPE_FISH)
		{
			Jump();
		}
		else if(animalType == AnimalType.TYPE_BEAR)
		{
		}
		else if(animalType == AnimalType.TYPE_RABBIT)
		{
			Jump();
		}
	}

	public void Jump()
	{
		if(isGroundedL || isGroundedR)
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
			scaler = interactableObject.GetComponent<AnimalController>().scaler;
			Vector3 scaleChange = new Vector3(scaler, scaler, 0);
			transform.localScale = Vector3.Lerp(transform.localScale, scaleChange, 2);
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
