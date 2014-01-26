using UnityEngine;
using System.Collections;

public class buttoncollide : MonoBehaviour {


	public GameObject blockToDestroy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		print ("destroy");
		Destroy(blockToDestroy);
	}
}
