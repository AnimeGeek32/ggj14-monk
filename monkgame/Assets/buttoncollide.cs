using UnityEngine;
using System.Collections;

public class buttoncollide : MonoBehaviour {
	private Animator _animator;


	public GameObject blockToDestroy;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		print ("destroy");
		_animator.SetBool ("Pressed", true);
		Destroy(blockToDestroy);
	}
}
