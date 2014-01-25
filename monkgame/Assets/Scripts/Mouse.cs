using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour
{
	public GameObject particle;
	private Vector3 StartPoint { get; set; }
	public Vector2 EndPoint { get; set; }
	public float Speed { get; set; }
	private float timer;
	
	// Use this for initialization
	void Start () {
		StartPoint = particle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime/Speed;
		particle.transform.position = Vector2.Lerp (StartPoint, EndPoint, timer);
		if (timer >= 1) {
			Destroy(particle);
		}
	}

	void OnMouseDown ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Destroy (particle);
		}
	}
}
