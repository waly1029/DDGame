﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour {

	[SerializeField]
    private int maxPlayerHealth;

	[SerializeField]
    private static int playerHealth;

    [SerializeField]
    private Slider healthBar;

    public bool isDead;

    private LifeManager lifeManager;

    private TimeManager timeManager;

	private LevelManager levelManager;

	// Use this for initialization
	void Start ( ) {

        healthBar = transform.FindChild( "Slider" ).GetComponent<Slider> ( );

        playerHealth = PlayerPrefs.GetInt( "PlayerCurrentHealth" );

        levelManager = FindObjectOfType<LevelManager> ( );

        lifeManager = FindObjectOfType<LifeManager> ( );

        timeManager = FindObjectOfType<TimeManager> ( );

        playerHealth = maxPlayerHealth;

        isDead = false;

    }
	
	// Update is called once per frame
	void Update ( ) {
		
	}

    public void Health( ) {
        
        if ( playerHealth <= 0 && !isDead ) {
			
            Debug.Log( "Dead" );

            playerHealth = 0;

            levelManager.RespawnPlayer( );

            lifeManager.TakeLife( );

            isDead = true;

            timeManager.RestTime( );

        }

        if ( playerHealth > maxPlayerHealth ) {
			
            playerHealth = maxPlayerHealth;

        }

        healthBar.value = playerHealth;

    }

    public static void HurtPlayer( int damageToGive ) {
		
        playerHealth -= damageToGive;

        PlayerPrefs.SetInt( "PlayerCurrentHealth", playerHealth );

    }

    public void FullHealth( ) {

        playerHealth = PlayerPrefs.GetInt( "PlayerMaxHealth" );

        PlayerPrefs.SetInt( "PlayerCurrentHealth", playerHealth );

    }

    public void KillPlayer( ) {
		
        playerHealth = 0;

    }
}