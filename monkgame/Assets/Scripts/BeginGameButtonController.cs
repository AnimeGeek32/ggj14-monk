using UnityEngine;
using System.Collections;

public class BeginGameButtonController : MonoBehaviour {
	public string destinationScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
