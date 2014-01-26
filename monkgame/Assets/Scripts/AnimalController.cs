using UnityEngine;
using System.Collections;

public enum AnimalType {
	TYPE_NONE,
	TYPE_CAT,
	TYPE_MOUSE,
	TYPE_BEAR,
	TYPE_FISH,
	TYPE_RABBIT
}

public class AnimalController : MonoBehaviour {
	//for all
	public float speed = 30.0f;
	public float maxSpeed = 5f;
	public float jumpPower = 500f;

	//FOR CAT
	public bool fallDeath = true;
	// for mouse we need a scale set to make monk smaller
	public float scaler;
	// for fish we need a waterdeath bool
	public float strength;


	public AnimalType animalType = AnimalType.TYPE_NONE;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
