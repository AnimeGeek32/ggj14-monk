using UnityEngine;
using System.Collections;

public class crusherLoop : MonoBehaviour {
	private float width;
	private float height;
	private float timer = 0;
	private Vector3 startTrans;
	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		width = renderer.bounds.size.x;
		height = renderer.bounds.size.y;
		startTrans = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer < 2){
			float increTrans = transform.position.y - (height / 20);
			targetPosition = new Vector3(transform.position.x, increTrans, 0);
		}
		if(timer >= 2){
			targetPosition = startTrans;
			timer = 0;
	}

		transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * 20);
}
}
