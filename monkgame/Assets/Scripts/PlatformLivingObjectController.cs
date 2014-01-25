using UnityEngine;
using System.Collections;

public class PlatformLivingObjectController : MonoBehaviour {
	
	public enum LivingObjectType {
		TYPE_RABBIT,
		TYPE_CAT,
		TYPE_FISH,
		TYPE_BIRD
	}

	public LivingObjectType livingObjectType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UseBorrowedPower(GameObject borrower)
	{
		if(livingObjectType == LivingObjectType.TYPE_RABBIT)
		{
			PlatformPlayerController playerController = borrower.GetComponent<PlatformPlayerController>();
			playerController.Jump();
		}
		else if(livingObjectType == LivingObjectType.TYPE_BIRD)
		{
			Debug.Log ("Monk flies away!");
		}
	}
}
