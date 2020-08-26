using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	public float restartDelay = 1f;

	GameObject completeLevelUI;
	bool gameHasEnded = false;

	void Awake()
	{
		GameObject gameManagerObject = FindInActiveObjectByName("LevelComplete"); //TODO can't find disabled objects with GameObject.Find();
		if (gameManagerObject == null)
		{
			throw new Exception("No LevelComplete GameObject found on the scene.");
		}
		this.completeLevelUI = gameManagerObject;
	}

	public void CompleteLevel ()
	{
		completeLevelUI.SetActive(true);
	}

	public void EndGame ()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			FindObjectOfType<AudioManager>().Play("GameOver");
			Invoke("Restart", restartDelay);
		}
	}

	void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	GameObject FindInActiveObjectByName(string name)
	{
		Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
		for (int i = 0; i < objs.Length; i++)
		{
			if (objs[i].hideFlags == HideFlags.None)
			{
				if (objs[i].name == name)
				{
					return objs[i].gameObject;
				}
			}
		}
		return null;
	}

}
