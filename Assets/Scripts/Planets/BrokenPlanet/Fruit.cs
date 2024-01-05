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



    public float force = 50;
    public float radius = 5;
    public float upliftModifer = 5;

    void Explode() {
        Vector3 explodePosition = explodable.transform.position;
		explodable.explode();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(explodePosition, radius);

        foreach (Collider2D coll in colliders)
        {
            if (coll.GetComponent<Rigidbody2D>() && coll.name == "Broken Planet piece")
            {
                AddExplosionForce(coll.GetComponent<Rigidbody2D>(), force, explodePosition, radius, upliftModifer);
            }
        }

    }

    private void AddExplosionForce(Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius, float upliftModifier = 0)
    {
        print("explode test");
        var dir = (body.transform.position - explosionPosition);
        float wearoff = 1 - (dir.magnitude / explosionRadius);
        Vector3 baseForce = dir.normalized * explosionForce * wearoff;
        baseForce.z = 0;
        body.AddForce(baseForce);

        if (upliftModifer != 0)
        {
            float upliftWearoff = 1 - upliftModifier / explosionRadius;
            Vector3 upliftForce = Vector2.up * explosionForce * upliftWearoff;
            upliftForce.z = 0;
            body.AddForce(upliftForce);
        }

    }














}
