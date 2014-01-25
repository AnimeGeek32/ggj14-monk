using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 30f;
	public float maxSpeed = 5f;
	public float jumpPower = 500f;
	public GameObject interactableObject;
	public AnimalType animalType = AnimalType.TYPE_NONE;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UsePower()
	{
		if(animalType == AnimalType.TYPE_NONE)
		{
			// Nothing at all
		}
		else if(animalType == AnimalType.TYPE_CAT)
		{
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

	public void Interact()
	{
		if(interactableObject != null)
		{
			animalType = interactableObject.GetComponent<AnimalController>().animalType;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "LivingObject")
		{
			interactableObject = other.gameObject;
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
