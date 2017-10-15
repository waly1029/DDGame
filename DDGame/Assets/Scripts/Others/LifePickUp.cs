using UnityEngine;
using System.Collections;

public class LifePickUp : MonoBehaviour {

    private LifeManager lifeSystem;
	// Use this for initialization
	void Start () {
        lifeSystem = FindObjectOfType<LifeManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            lifeSystem.GiveLife();
            Destroy(gameObject);
        }
    }
}
