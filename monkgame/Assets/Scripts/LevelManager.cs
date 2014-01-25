using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public Transform[] exitPoints;
	public AudioClip backgroundMusic;
	public GameObject playerObject;

	// Use this for initialization
	void Start () {
		GameObject playerInstance = (GameObject)Instantiate(playerObject, exitPoints[GameManager.Instance.exitPointID].position, Quaternion.identity);
		PlayerController currentPlayerController = playerInstance.GetComponent<PlayerController>();
		currentPlayerController.animalType = GameManager.Instance.animalType;
		currentPlayerController.speed = GameManager.Instance.monkSpeed;
		currentPlayerController.jumpPower = GameManager.Instance.monkJumpPower;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
