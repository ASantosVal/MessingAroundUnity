using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private Transform player;
    private Text scoreText;

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

        Text textComponent = scoreObject.GetComponent<Text>();
        if (textComponent == null)
        {
            throw new Exception("No Text component found on Score GameObject.");
        }
        this.scoreText = textComponent;
    }

    // Update is called once per frame
    void Update () {
        string currentScore = this.player.position.z.ToString("0");
        this.scoreText.text = currentScore;
    }
}
