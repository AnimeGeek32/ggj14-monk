using UnityEngine;
using System.Collections;

public class MousePaw : MonoBehaviour {
	public GameObject particle;
	public GameObject mouseObject;
	private int mouseCounter = 0;
	private float timer;
	
	// Use this for initialization
	void Start () {
		Instantiate (mouseObject, Camera.main.ScreenToWorldPoint(new Vector3(-512, -384, Camera.main.nearClipPlane)), Quaternion.identity);
		Instantiate (mouseObject, Camera.main.ScreenToWorldPoint(new Vector3(512, -384, Camera.main.nearClipPlane)), Quaternion.identity);
		Instantiate (mouseObject, Camera.main.ScreenToWorldPoint(new Vector3(-512, 384, Camera.main.nearClipPlane)), Quaternion.identity);
		Instantiate (mouseObject, Camera.main.ScreenToWorldPoint(new Vector3(512, 384, Camera.main.nearClipPlane)), Quaternion.identity);
		//mouseObject.transform.position.z
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (mouseCounter == 0) {
		} else if (Random.Range(1,3) <= timer) {
			Vector3 v3 = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-512, 512), Random.Range(-384, 384), Camera.main.nearClipPlane));
			GameObject mouseClone = Instantiate (mouseObject, v3, Quaternion.identity) as GameObject;
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
