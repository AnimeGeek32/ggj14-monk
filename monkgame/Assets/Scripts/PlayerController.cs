﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 30f;
    public float maxSpeed = 5f;
    public float jumpPower = 100f;
	public float Strength;
    public GameObject interactableObject;
    public AnimalType animalType = AnimalType.TYPE_NONE;
    public Transform groundTransforml;
    public Transform groundTransformr;
    public bool isGroundedL = false;
    public bool isGroundedR = false;
    private bool hasJumped = false;
    public bool fallDeath = true;
	public float orthoAdj;
    private float scaler;
	public Camera MainCam;
    public GameObject mouse;
    public GameObject fish;
    public GameObject rabbit;
    public GameObject cat;
    public GameObject bear;
	private GameObject currentAnimal;
    private Vector3 monkOriginScale;
    private float previousY;
    public float FallDeathTime = 1.5f;
    private float fallDeathTime = 0;
    private float originalGravityScale;
	private bool facingRight = true;
	public bool gonnaDie;

	public Sprite monk;


    public bool InWater = false;

    public static PlayerController Current;

    // Use this for initialization
    void Start()
    {
		MainCam = Camera.main;
		GetComponent <SpriteRenderer>().sprite = monk;
        monkOriginScale = transform.localScale;
        fallDeathTime = 0;
        originalGravityScale = gameObject.rigidbody2D.gravityScale;
        Current = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (animalType != AnimalType.TYPE_FISH && InWater)
        {
            DeathAction();
        }

        /* Animal selection inputs
         * 
         * 
         * */
        if (Input.GetButtonDown("mouse") && mouse != null)
        {
            interactableObject = mouse;
            if (animalType != interactableObject.GetComponent<AnimalController>().animalType)
                Interact();

        }

        if (Input.GetButtonDown("fish") && fish != null)
        {
            interactableObject = fish;
            if (animalType != interactableObject.GetComponent<AnimalController>().animalType)
            {
                Interact();
            }
        }

        if (Input.GetButtonDown("rabbit") && rabbit != null)
        {
            interactableObject = rabbit;
            if (animalType != interactableObject.GetComponent<AnimalController>().animalType)
                Interact();

        }
        if (Input.GetButtonDown("cat") && cat != null)
        {
            interactableObject = cat;
            if (animalType != interactableObject.GetComponent<AnimalController>().animalType)
                Interact();

        }
        if (Input.GetButtonDown("bear") && bear != null)
        {
            interactableObject = bear;
            if (animalType != interactableObject.GetComponent<AnimalController>().animalType)
                Interact();

        }

        if (!InWater)
        {
            isGroundedL = Physics2D.Linecast(transform.position, groundTransforml.position, 1 << LayerMask.NameToLayer("Ground"));
            isGroundedR = Physics2D.Linecast(transform.position, groundTransformr.position, 1 << LayerMask.NameToLayer("Ground"));

			if(isGroundedL || isGroundedR)
				fallDeathTime = 0;

            if (!isGroundedL && !isGroundedR)
            {
                if (previousY - transform.position.y >= 0)
                {
                    fallDeathTime += Time.deltaTime;
                    if (fallDeathTime >= FallDeathTime && fallDeath == true)
                    {
                        //DeathAction();
						gonnaDie = true;
                    }
                }
                else
                {
                    fallDeathTime = 0;
                }
            }
            previousY = transform.position.y;
        }

        if (Input.GetButtonDown("Jump"))
        {
            UsePower();
        }
        /*
        if(Input.GetAxis("Vertical") > 0)
        {
            Interact();
        }
        */
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
		Vector3 flipScale = transform.localScale;
		if(h < 0)
		{
			if(facingRight)
			{
				flipScale.x = -1 * transform.localScale.x;
				facingRight = false;
			}
		}
		else if(h > 0)
		{
			if(!facingRight)
			{
				flipScale.x = -1 * transform.localScale.x;
				facingRight = true;
			}
		}
		transform.localScale = flipScale;
			
        if (!InWater)
        {
            if (animalType != AnimalType.TYPE_FISH)
            {
                // If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
                if (h * rigidbody2D.velocity.x < maxSpeed)
                    // ... add a force to the player.
                    rigidbody2D.AddForce(Vector2.right * h * speed);

                // If the player's horizontal velocity is greater than the maxSpeed...
                if (Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
                    // ... set the player's velocity to the maxSpeed in the x axis.
                    rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
            }

            if (hasJumped && (isGroundedL || isGroundedR))
            {
                rigidbody2D.AddForce(new Vector2(0, jumpPower));
                hasJumped = false;
            }
        }
        else if (animalType == AnimalType.TYPE_FISH)
        {
            float v = Input.GetAxis("Vertical");
            rigidbody2D
                .transform.Translate(h * Time.deltaTime * maxSpeed, v * Time.deltaTime * maxSpeed, 0f);
        }
    }

    public void UsePower()
    {
        if (animalType == AnimalType.TYPE_NONE)
        {
            // Nothing at all
			Jump ();
        }
        else if (animalType == AnimalType.TYPE_CAT)
        {
            Jump();
        }
        else if (animalType == AnimalType.TYPE_MOUSE)
        {
            Jump();
        }
        else if (animalType == AnimalType.TYPE_FISH)
        {
            Jump();
        }
        else if (animalType == AnimalType.TYPE_BEAR)
        {
			Jump ();
        }
        else if (animalType == AnimalType.TYPE_RABBIT)
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (isGroundedL || isGroundedR)
            hasJumped = true;
    }

    public void Interact()
    {
        if (interactableObject != null)
        {
           animalType = interactableObject.GetComponent<AnimalController>().animalType;
            fallDeath = interactableObject.GetComponent<AnimalController>().fallDeath;
            speed = interactableObject.GetComponent<AnimalController>().speed;
            maxSpeed = interactableObject.GetComponent<AnimalController>().maxSpeed;
            jumpPower = interactableObject.GetComponent<AnimalController>().jumpPower;
            scaler = interactableObject.GetComponent<AnimalController>().scaler;
            Vector3 scaleChange = new Vector3(scaler, scaler, 0);
            transform.localScale = Vector3.Lerp(transform.localScale, scaleChange, 2);
			GetComponent<SpriteRenderer>().sprite = interactableObject.GetComponent<SpriteRenderer>().sprite;
			BoxCollider2D monkBox = (BoxCollider2D)GetComponent<BoxCollider2D>();
			monkBox.size = interactableObject.GetComponent<BoxCollider2D>().size;
			rigidbody2D.mass = interactableObject.GetComponent<AnimalController>().mass;
			MainCam.orthographicSize = interactableObject.GetComponent<AnimalController>().orthoAdj;
			if(interactableObject.GetComponent<AnimalController>().offset != 0){
				foreach (Transform child in transform)
				{
					float offsetY = child.transform.position.y - interactableObject.GetComponent<AnimalController>().offset;
					//child is your child transform
					child.position = new Vector3(child.transform.position.x, offsetY,0);
				}
			}
			if(!facingRight)
			{
				Vector3 flipScale = transform.localScale;
				flipScale.x = -1 * transform.localScale.x;
				transform.localScale = flipScale;
			}
        }
    }

    public void WaterJump()
    {
        rigidbody2D.AddForce(new Vector2(jumpPower, jumpPower * 2.5f));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("water"))
        {
            gameObject.rigidbody2D.gravityScale = 0.001f;
            InWater = true;
        }
        else if (other.CompareTag("notInWater") && InWater)
        {
            gameObject.rigidbody2D.gravityScale = originalGravityScale;
            WaterJump();
            InWater = false;
        }
        else if (other.name == "crusher" || other.name == "deathGround")
        {
            DeathAction();
        }
    }

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "ground" && fallDeath == true && gonnaDie == true)
		{
			DeathAction();
		}
	}
	
	public void DeathAction()
    {
		Application.LoadLevel (Application.loadedLevelName);
    }


}