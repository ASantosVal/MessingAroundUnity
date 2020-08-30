using System;
using UnityEngine;

public class EndTrigger : MonoBehaviour {

	private GameManager gameManager;

	void Awake()
	{
		GameObject gameManagerObject = GameObject.Find("GameManager");
		if (gameManagerObject == null)
		{
			throw new Exception("No GameManager GameObject found on the scene.");
		}
		GameManager gameManager = gameManagerObject.GetComponent<GameManager>();
		if (gameManager == null)
		{
			throw new Exception("No GameManager component found on GameManager GameObject.");
		}
		this.gameManager = gameManager;
	}

	void OnTriggerEnter ()
	{
		gameManager.CompleteLevel();
	}

}
