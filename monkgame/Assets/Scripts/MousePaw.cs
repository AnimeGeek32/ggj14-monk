using UnityEngine;
using System.Collections;

public class MousePaw : MonoBehaviour {
	public GameObject particle;
	public GameObject mouseObject;
	public GameObject[] spawnPoints;
	private int mouseCounter = 10;
	private float timer;
	private const float LEFT = -5.12f;
	private const float TOP = -3.84f;
	private const float RIGHT = 5.12f;
	private const float BOTTOM = 3.84f;
	
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		/*Instantiate (mouseObject, (new Vector3(LEFT, TOP, 0)), Quaternion.identity);
		Instantiate (mouseObject, (new Vector3(LEFT, BOTTOM, 0)), Quaternion.identity);
		Instantiate (mouseObject, (new Vector3(RIGHT, TOP, 0)), Quaternion.identity);
		Instantiate (mouseObject, (new Vector3(RIGHT, BOTTOM, 0)), Quaternion.identity);*/
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (mouseCounter == 0) {
		} else if (Random.Range(1f,3f) <= timer) {
			Vector3 v3, v3end;
			if(0.5f < Random.Range (0.0f, 1.0f)) {
				if(0.5f < Random.Range (0.0f, 1.0f)) {
					v3 = new Vector3(Random.Range(LEFT, RIGHT), TOP, 0);
					v3end = new Vector3(Random.Range(LEFT, RIGHT), BOTTOM, 0);
				} else {
					v3 = new Vector3(Random.Range(LEFT, RIGHT), BOTTOM, 0);
					v3end = new Vector3(Random.Range(LEFT, RIGHT), TOP, 0);
				}
			} else {
				if(0.5f < Random.Range (0.0f, 1.0f)) {
					v3 = new Vector3(LEFT, Random.Range(TOP, BOTTOM), 0);
					v3end = new Vector3(RIGHT, Random.Range(TOP, BOTTOM), 0);
				} else {
					v3 = new Vector3(RIGHT, Random.Range(TOP, BOTTOM), 0);
					v3end = new Vector3(LEFT, Random.Range(TOP, BOTTOM), 0);
				}
			}

			GameObject mouseClone = Instantiate (mouseObject, v3, Quaternion.identity) as GameObject;
			Mouse mouse = mouseClone.GetComponent("Mouse") as Mouse;
			if(mouse != null) {
				mouse.EndPoint = v3end;
				mouse.Speed = mouseCounter + 1;
			}
			mouseCounter--;
			timer = 0;
		}
		Vector3 mouseToWorldPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 newPosition = new Vector3 ();
		newPosition.x = mouseToWorldPosition.x;
		newPosition.y = mouseToWorldPosition.y;
		newPosition.z = particle.transform.position.z;
		particle.transform.position = newPosition;
	}
}
