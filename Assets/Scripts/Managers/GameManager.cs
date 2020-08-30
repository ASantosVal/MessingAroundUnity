using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public float restartDelay = 1f;

	GameObject completeLevelUI;
	LocalSceneManager customSceneManager;
	bool gameHasEnded = false;

	void Awake()
	{
		GameObject gameManagerObject = FindInActiveObjectByName("LevelComplete"); //can't find disabled objects with GameObject.Find();
		if (gameManagerObject == null)
		{
			throw new Exception("No LevelComplete GameObject found on the scene.");
		}
		this.completeLevelUI = gameManagerObject;
		GameObject sceneManagerObject = GameObject.Find("SceneManager");
		if (sceneManagerObject == null)
		{
			throw new Exception("No SceneManager GameObject found on the scene.");
		}
		LocalSceneManager sceneManager = sceneManagerObject.GetComponent<LocalSceneManager>();
		if (sceneManager == null)
		{
			throw new Exception("No LocalSceneManager component found on SceneManager GameObject.");
		}
		this.customSceneManager = sceneManager;
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
		customSceneManager.ReloadScene();
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
