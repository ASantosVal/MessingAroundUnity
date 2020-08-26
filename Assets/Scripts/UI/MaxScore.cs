using System;
using UnityEngine;
using UnityEngine.UI;

public class MaxScore : MonoBehaviour
{
	Transform player;
	Text scoreText;
	Text maxScoreText;

	void Awake()
	{
		GameObject playerObject = GameObject.Find("Player");
		if (playerObject == null)
		{
			throw new Exception("No Player GameObject found on the scene.");
		}
		this.player = playerObject.transform;

		GameObject scoreObject = GameObject.Find("Score");
		if (scoreObject == null)
		{
			throw new Exception("No Score GameObject found on the scene.");
		}

		Text scoreTextComponent = scoreObject.GetComponent<Text>();
		if (scoreTextComponent == null)
		{
			throw new Exception("No Text component found on Score GameObject.");
		}
		this.scoreText = scoreTextComponent;

		GameObject maxScoreObject = GameObject.Find("MaxScore");
		if (maxScoreObject == null)
		{
			throw new Exception("No Score MaxScore found on the scene.");
		}

		Text maxScoreText = maxScoreObject.GetComponent<Text>();
		if (maxScoreText == null)
		{
			throw new Exception("No Text component found on MaxScore GameObject.");
		}
		this.maxScoreText = maxScoreText;
	}

	void Start()
	{
		this.maxScoreText.text = PlayerPrefs.GetFloat("HighScore", 0f).ToString("0");
	}

	void Update()
	{
		float currentPosition = player.position.z;
		this.scoreText.text = currentPosition.ToString("0");

		if (PlayerPrefs.GetFloat("HighScore", 0f) < currentPosition)
		{
			PlayerPrefs.SetFloat("HighScore", player.position.z);
			this.maxScoreText.text = currentPosition.ToString("0");
		}
	}

	public void ResetScore()
	{		
		PlayerPrefs.DeleteKey("HighScore");
	}
}
