using UnityEngine;
using System.Collections;

public class CameraLockOnController : MonoBehaviour {
	public GameObject targetObject;
	public float switchingTime = 0.5f;

	private bool isSwitchingLockOnTarget = false;
	private Vector2 prevPosition;

	// Use this for initialization
	void Start () {
		Vector3 targetPosition = targetObject.transform.position;
		targetPosition.z = transform.position.z;
		transform.position = targetPosition;
		prevPosition.x = transform.position.x;
		prevPosition.y = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		if(isSwitchingLockOnTarget)
		{
			newPosition = MoveToAnotherTarget(newPosition);
		}
		else
		{
			newPosition.x = targetObject.transform.position.x;
			newPosition.y = targetObject.transform.position.y;

			// Check input
			if(Input.GetMouseButtonDown(0))
			{
				//Debug.Log("Mouse down.");
				Vector2 mouseToWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast(mouseToWorldPosition, Vector2.zero, Mathf.Infinity, 1 << LayerMask.NameToLayer("CameraLockOnTargets"));
				if(hit.collider != null)
				{
					//Debug.Log("Mouse hits target: " + hit.collider.name);
					targetObject = hit.collider.gameObject;
					StartCoroutine("SwitchCameraTargets", switchingTime);
				}
			}
		}

		transform.position = newPosition;
	}

	Vector3 MoveToAnotherTarget(Vector3 objectPosition)
	{
		Vector3 changedPosition = objectPosition;
		if(transform.position.x < targetObject.transform.position.x)
		{
			float distanceInterval = targetObject.transform.position.x - prevPosition.x;
			changedPosition.x += distanceInterval * (Time.deltaTime / switchingTime);
		}
		else if(transform.position.x > targetObject.transform.position.x)
		{
			float distanceInterval = targetObject.transform.position.x - prevPosition.x;
			changedPosition.x += distanceInterval * (Time.deltaTime / switchingTime);
		}
		
		if(transform.position.y < targetObject.transform.position.y)
		{
			float distanceInterval = targetObject.transform.position.y - prevPosition.y;
			changedPosition.y += distanceInterval * (Time.deltaTime / switchingTime);
		}
		else if(transform.position.y > targetObject.transform.position.y)
		{
			float distanceInterval = targetObject.transform.position.y - prevPosition.y;
			changedPosition.y += distanceInterval * (Time.deltaTime / switchingTime);
		}
		return changedPosition;
	}

	IEnumerator SwitchCameraTargets(float seconds)
	{
		isSwitchingLockOnTarget = true;
		yield return new WaitForSeconds(seconds);
		isSwitchingLockOnTarget = false;
		prevPosition.x = targetObject.transform.position.x;
		prevPosition.y = targetObject.transform.position.y;
	}
}
