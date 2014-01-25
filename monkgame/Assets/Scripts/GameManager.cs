using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager {
	private static GameManager instance;

	public AnimalType animalType;
	public int exitPointID;
	public float monkSpeed;
	public float monkMaxSpeed;
	public float monkJumpPower;
	public bool monkFallDeath;

	public GameManager()
	{
		if(instance != null)
		{
			Debug.LogError("Cannot have two game managers at the same time.");
			return;
		}
		else
		{
			animalType = AnimalType.TYPE_NONE;
			exitPointID = 0;
			monkSpeed = 30.0f;
			monkJumpPower = 500f;
			monkFallDeath = true;
		}
		
		instance = this;
	}

	public static GameManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new GameManager();
			}
			
			return instance;
		}
	}

	public void Reset()
	{
		animalType = AnimalType.TYPE_NONE;
		exitPointID = 0;
		monkSpeed = 30.0f;
		monkJumpPower = 500f;
		monkFallDeath = true;
	}
}
