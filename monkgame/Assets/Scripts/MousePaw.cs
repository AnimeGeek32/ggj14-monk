using UnityEngine;
using System.Collections;

public class MousePaw : MonoBehaviour {
	public GameObject particle;
	public GameObject mouseObject;
	private int mouseCounter = 10;
	private float timer;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (mouseCounter == 0) {
		} else if (Random.Range(1,3) <= timer) {
			Vector3 v3, v3end;
			if(0.5f < Random.Range (0.0f, 1.0f)) {
				if(0.5f < Random.Range (0.0f, 1.0f)) {
					v3 = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, 512), 0, Camera.main.nearClipPlane));
					v3end = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, 512), 384, Camera.main.nearClipPlane));
				} else {
					v3 = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, 512), 384, Camera.main.nearClipPlane));
					v3end = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, 512), 0, Camera.main.nearClipPlane));
				}
			} else {
				if(0.5f < Random.Range (0.0f, 1.0f)) {
					v3 = Camera.main.ScreenToWorldPoint(new Vector3(0, Random.Range(0, 384), Camera.main.nearClipPlane));
					v3end = Camera.main.ScreenToWorldPoint(new Vector3(512, Random.Range(0, 384), Camera.main.nearClipPlane));
				} else {
					v3 = Camera.main.ScreenToWorldPoint(new Vector3(512, Random.Range(0, 384), Camera.main.nearClipPlane));
					v3end = Camera.main.ScreenToWorldPoint(new Vector3(0, Random.Range(0, 384), Camera.main.nearClipPlane));
				}
			}

			GameObject mouseClone = Instantiate (mouseObject, v3, Quaternion.identity) as GameObject;
			Mouse mouse = mouseClone.GetComponent("Mouse") as Mouse;
			if(mouse != null) {
				mouse.EndPoint = v3end;
				mouse.Speed = mouseCounter;
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
