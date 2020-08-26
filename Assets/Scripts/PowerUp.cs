using System;
using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float sizeMultiplier = 1.5f;
    public float boost = 10f;
    public float waitTime = 5f;
    public GameObject pickupEffect;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine(Pickup(other));
        }
    }
    IEnumerator Pickup(Collider player)
    {
        Debug.Log("PowerUp picked!");
        Instantiate(pickupEffect, transform.position, transform.rotation);

        player.transform.localScale *= sizeMultiplier;
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement == null)
        {
            throw new Exception("No PlayerMovement component found on Player GameObject.");
        }
        playerMovement.booster = sizeMultiplier;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(waitTime);
        player.transform.localScale /= sizeMultiplier;
        playerMovement.booster /= boost;

        Destroy(gameObject);
    }
}
