using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {

	public fruitScore fruitScore;
	private TextMesh scoreText;
	// Use this for initialization
	void Start () {
		fruitScore = GameObject.Find("basket").GetComponent<fruitScore>();
		scoreText = gameObject.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		// Set the text of the attached Text mesh
		string printScore = fruitScore.score.ToString ();
		scoreText.text = printScore;
	
	}
}
