using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour
{
	public GameObject particle;
	public AudioClip squeekSound;
	private Vector2 StartPoint { get; set; }
	public Vector2 EndPoint { get; set; }
	public float Speed { get; set; }
	private float timer;
	
	// Use this for initialization
	void Start () {
		StartPoint = particle.transform.position;
		Vector2 dif = EndPoint - StartPoint;
		particle.transform.Rotate (Vector3.forward * (180.0f / Mathf.PI) * Mathf.Atan2(dif.y, dif.x));
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime/Speed;
		if (Speed > 1) {
			particle.transform.position = Vector2.Lerp (StartPoint, EndPoint, timer);
			if (timer >= 1) {
				Destroy (particle);
			}
		}
	}

	void OnMouseDown ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Camera.main.audio.PlayOneShot(squeekSound);
			Destroy (particle);
		}
	}
}
