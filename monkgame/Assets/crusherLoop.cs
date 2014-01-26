using UnityEngine;
using System.Collections;

public class crusherLoop : MonoBehaviour {
	private float timer = 0;
	private Vector3 startTrans;
	public Transform targetPosition;
	public float speed;

	// Use this for initialization
	void Start () {
		startTrans = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime * speed;
		if (timer > 0) {
			transform.position = Vector3.Lerp(startTrans, targetPosition.position, timer);
		} else if (timer < 0) {
			transform.position = Vector3.Lerp(targetPosition.position, startTrans, -timer);
		}
		if (Mathf.Abs (timer) > 1) {
			speed = -speed;
			timer = 0;
		}
	}
}