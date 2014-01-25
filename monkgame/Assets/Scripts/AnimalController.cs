using UnityEngine;
using System.Collections;

public enum AnimalType {
	TYPE_NONE,
	TYPE_CAT,
	TYPE_MOUSE,
	TYPE_BIRD,
	TYPE_FISH
}

public class AnimalController : MonoBehaviour {
	public float speed = 30.0f;
	public float maxSpeed = 5f;
	public float jumpPower = 500f;
	public AnimalType animalType = AnimalType.TYPE_NONE;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
