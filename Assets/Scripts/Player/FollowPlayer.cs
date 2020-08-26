using System;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Vector3 offset;
	private Transform player;

	void Awake()
	{
		GameObject playerObject = GameObject.Find("Player");
		if (playerObject == null)
        {
			throw new Exception("No Player GameObject found on the scene.");
		}
		player = playerObject.transform;
	}
	void Update()
	{
		transform.position = player.position + offset;
	}
}
