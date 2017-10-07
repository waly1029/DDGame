using UnityEngine;
using System.Collections;

public class EnemyStarController : MonoBehaviour {

    public float speed;

    public PlayerController player;

    public GameObject impactEffect;

    public float rotationSpeed;

    public int damageToGive;

	public HealthManager playerHealth;

    public LifeManager playerLife;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

		playerHealth = FindObjectOfType<HealthManager> ();

        playerLife = FindObjectOfType<LifeManager>();

        if (playerLife.lifeCounter >= 0)
        {
            if (player.transform.position.x < transform.position.x)
            {
                speed = -speed;

                rotationSpeed = -rotationSpeed;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

        GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Debug.Log("touchPlayer");

            HealthManager.HurtPlayer(damageToGive);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

