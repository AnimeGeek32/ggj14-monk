using UnityEngine;
using System.Collections;

public class AnyKeySceneTransitionController : MonoBehaviour {
	public string destinationScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKey)
		{
			Application.LoadLevel(destinationScene);
		}
	}
}
