using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour {

    [SerializeField]
    private int maxPlayerHealth;

    public static int playerHealth;

    [SerializeField]
    private Slider healthBar;

    public bool isDead;

    private LifeController lifeCor;

    private TimeController timeCor;

    private LevelManager levelManager;

    // Use this for initialization
    void Start( ) {

        healthBar = transform.Find( "Slider" ).GetComponent<Slider>( );

        playerHealth = PlayerPrefs.GetInt( "PlayerCurrentHealth" );

        levelManager = FindObjectOfType<LevelManager>( );

        lifeCor = FindObjectOfType<LifeController>( );

        timeCor = FindObjectOfType<TimeController>( );

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

            levelManager.RespawnPlayer( );

            lifeCor.TakeLife( );

            isDead = true;

            timeCor.RestTime( );

        }

        if ( playerHealth > maxPlayerHealth ) {

            playerHealth = maxPlayerHealth;

        }

    }

    public void DrawHealth( ) {

        healthBar.value = playerHealth;

    }
    
}
