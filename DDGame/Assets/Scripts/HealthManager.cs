using UnityEngine;
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

    private LifeManager lifeSystem;

    private TimeManager theTime;

	private LevelManager levelManager;

	// Use this for initialization
	void Start ( ) {

        playerHealth = maxPlayerHealth;

        healthBar = GetComponent<Slider> ( );

        playerHealth = PlayerPrefs.GetInt( "PlayerCurrentHealth" );

        levelManager = FindObjectOfType<LevelManager> ( );

        isDead = false;

        lifeSystem = FindObjectOfType<LifeManager> ( );

        theTime = FindObjectOfType<TimeManager> ( );
	}
	
	// Update is called once per frame
	void Update ( ) {
		
        if ( playerHealth <= 0 && !isDead ) {
			
            Debug.Log( "Dead" );

            playerHealth = 0;

            levelManager.RespawnPlayer( );

            lifeSystem.TakeLife( );

            isDead = true;

            theTime.RestTime( );

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
