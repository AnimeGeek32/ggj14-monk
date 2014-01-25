using UnityEngine;
using System.Collections;

public class dropFruit : MonoBehaviour {

	public GameObject fruit;

	public float floatHeight;
	public float liftForce;
	public float damping;
	private float timer;
	private int fruitDex = 0;
	private GameObject newFruit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if(timer >= 2){
			float randX = Random.Range (-3.5f,2.0f);
			float randY = Random.Range (1.1f, 3.5f);
			Vector2 pos = new Vector2(randX,randY);
			newFruit = (GameObject)Instantiate(fruit,pos,Quaternion.identity);
			newFruit.rigidbody2D.isKinematic = true;
			fruitDex++;
			newFruit.name = "fruit";
			timer = 0;
		}


		if(Input.GetMouseButtonDown(0)){
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hit != null && hit.collider.gameObject.tag == "fruit") {

				print (hit.point);
				//GameObject newFruit = (GameObject)Instantiate(fruit, hit.point,Quaternion.identity);
				hit.collider.gameObject.rigidbody2D.isKinematic = false;
			}
		}
	}
}
