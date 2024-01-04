using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
	public Explodable explodable;
	public PlayerController_new player;
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			player.ImmediateLaunch();
			Invoke("Explode", 1);
			gameObject.SetActive(false);
		}
	}
	void Explode() {
		explodable.explode();
	}
}
