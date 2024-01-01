using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleItem : MonoBehaviour
{
    public UIWhaleItem ui;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            ui.Increase();
            Destroy(gameObject);
        }
    }
}
