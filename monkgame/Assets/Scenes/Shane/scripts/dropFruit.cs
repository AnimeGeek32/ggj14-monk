using UnityEngine;
using System.Collections;

public class dropFruit : MonoBehaviour {

	public GameObject fruit;

	public float floatHeight;
	public float liftForce;
	public float damping;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hit != null) {
				print (hit.point);
				GameObject newFruit = (GameObject)Instantiate(fruit, hit.point,Quaternion.identity);

			}
		}
	}
}
