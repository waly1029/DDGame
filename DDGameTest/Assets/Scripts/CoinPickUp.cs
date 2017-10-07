using UnityEngine;
using System.Collections;

public class CoinPickUp : MonoBehaviour {

    public int pointsToAdd;

    public AudioSource coinSoundEffect;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() == null)
        {
            return;
        }
        ScoreManager.AddPionts(pointsToAdd);

        coinSoundEffect.Play();

        Destroy(gameObject);
    }
}
