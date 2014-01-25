using UnityEngine;
using System.Collections;

public class PlatformCameraFollowController : MonoBehaviour {
	public Transform targetObject;

	// Use this for initialization
	void Start () {
		Vector3 newPosition = transform.position;
		newPosition.x = targetObject.position.x;
		//newPosition.y = targetObject.position.y;
		transform.position = newPosition;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.x = targetObject.position.x;
		//newPosition.y = targetObject.position.y;
		transform.position = newPosition;
	}
}
