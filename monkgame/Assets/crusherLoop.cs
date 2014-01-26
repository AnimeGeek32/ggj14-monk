using UnityEngine;
using System.Collections;

public class crusherLoop : MonoBehaviour {
	private float width;
	private float height;
	private float timer = 0;
	private Transform startTrans;
	public GameObject targetPosition;
	public float speed;

	// Use this for initialization
	void Start () {
		width = renderer.bounds.size.x;
		height = renderer.bounds.size.y;
		startTrans = transform;

	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if(timer < 2){
			float increTrans = transform.position.y - (height / 20);
			//targetPosition = new Vector3(transform.position.x, increTrans, 0);
			transform.position = Vector2.Lerp(transform.position, targetPosition.transform.position, Time.deltaTime * speed);
		}
		if(timer >= 2){
			float increTrans = startTrans.position.y + (height / 20);
			//targetPosition = new Vector3(transform.position.x, increTrans, 0);
			transform.position = Vector2.Lerp(targetPosition.transform.position, startTrans.position, Time.deltaTime * speed);
	}
		if(timer >= 5)
			timer = 0;
}
	
}
