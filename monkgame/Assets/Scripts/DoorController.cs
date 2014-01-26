using UnityEngine;
using System.Collections;

class DoorController : MonoBehaviour {
	public string sceneName;
	public int exitPointId;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			GameManager.Instance.exitPointID = exitPointId;
			Application.LoadLevel (sceneName);
		}
	}
}