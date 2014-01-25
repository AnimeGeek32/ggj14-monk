using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour
{
	public GameObject particle;

	void OnMouseDown ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Destroy (particle);
		}
	}
}
