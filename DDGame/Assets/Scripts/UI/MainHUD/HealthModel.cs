using UnityEngine;
using System.Collections;

public class HealthModel : MonoBehaviour {

    [SerializeField]
    private int maxPlayerHealth;

    public static int playerHealth;

    public bool isDead;

    private TimeController timeCor;

    private LevelManager levelManager;

    // Use this for initialization
    void Start( ) {

        playerHealth = PlayerPrefs.GetInt( "PlayerCurrentHealth" );

        levelManager = FindObjectOfType<LevelManager>( );

        playerHealth = maxPlayerHealth;

        isDead = false;

    }

    // Update is called once per frame
    void Update( ) {

    }

    public void Health( ) {

        if ( playerHealth <= 0 && !isDead ) {

            Debug.Log( "Dead" );

            playerHealth = 0;

            isDead = true;

			levelManager.RespawnPlayer( );

        }

        if ( playerHealth > maxPlayerHealth ) {

            playerHealth = maxPlayerHealth;

        }

    }
    
}
