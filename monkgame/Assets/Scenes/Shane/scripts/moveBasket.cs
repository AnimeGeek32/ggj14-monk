using UnityEngine;
using System.Collections;

public class moveBasket : MonoBehaviour {

	private float timer;
	public float smoothFactor;
	private float rand;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if(timer >=3){
			rand = Random.Range(-50,25);
			timer = 0;
		}
			//float rand = 
			Vector3 targetPosition = new Vector3 (rand, transform.position.y, 0);
			//transform.Translate(Random.Range (-100,100)*Time.deltaTime,0,0);
			transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * smoothFactor);
	
	}
}
