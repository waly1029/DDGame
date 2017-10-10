using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {
    public int healthToGive;

    public AudioSource pickUpSound;
	// Use this for initialization
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>() == null)
        { return; }

        HealthManager.HurtPlayer(-healthToGive);

        pickUpSound.Play();

        Destroy(gameObject);
    }
}
