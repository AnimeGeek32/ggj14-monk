using UnityEngine;
using System.Collections;

public class BeginGameButtonController : MonoBehaviour {
	public string destinationScene;
	public float endOfCounterClockWise = 20f;
	public float endOfClockWise = -20f;
	public float rotationInterval = 45f;

	private float currentRotation = 0.0f;
	private bool isClockwise = true;
	private bool isBeingHovered = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion newRotation = transform.rotation;
		Vector3 newAngles = newRotation.eulerAngles;

		if(isClockwise)
		{
			if(currentRotation < endOfClockWise)
			{
				isClockwise = false;
			}
			else
			{
				currentRotation -= rotationInterval * Time.deltaTime;
			}
		}
		else
		{
			if(currentRotation > endOfCounterClockWise)
			{
				isClockwise = true;
			}
			else
			{
				currentRotation += rotationInterval * Time.deltaTime;
			}
		}
		
		newAngles.z = currentRotation;
		newRotation.eulerAngles = newAngles;
		transform.rotation = newRotation;

		if(Input.GetMouseButtonDown(0))
		{
			Vector2 mouseToWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(mouseToWorldPosition, Vector2.zero);
			if(hit.collider == gameObject.collider2D)
			{
				Application.LoadLevel(destinationScene);
			}
		}
	}
}
