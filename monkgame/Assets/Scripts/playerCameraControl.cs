using UnityEngine;
using System.Collections;

public class playerCameraControl : MonoBehaviour {
	public GameObject targetObject;

	// Use this for initialization
	void Start () {
		Vector3 newPosition = transform.position;
		targetObject = GameObject.FindGameObjectWithTag("Player");
		newPosition.x = targetObject.transform.position.x;
		newPosition.y = targetObject.transform.position.y;
		transform.position = newPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if(targetObject != null)
		{
			Vector3 newPosition = transform.position;
			newPosition.x = targetObject.transform.position.x;
			newPosition.y = targetObject.transform.position.y;
			transform.position = newPosition;
		}
	}
}
