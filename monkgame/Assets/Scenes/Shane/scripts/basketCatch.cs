using UnityEngine;
using System.Collections;

public class basketCatch : MonoBehaviour {
	
	private fruitScore baskScore;

	// Use this for initialization
	void Start () {
		baskScore = GameObject.Find ("basket").GetComponent<fruitScore>(); 
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.name == "bask.bottom"){ 
			print("hit");

			baskScore.score++;
			print (baskScore.score);
			Destroy (gameObject);
		}

		if(collision.gameObject.name == "ground"){ 
			print("hit");
			
			baskScore.score--;
			print (baskScore.score);
			Destroy (gameObject, 2);
		}
	}


}
