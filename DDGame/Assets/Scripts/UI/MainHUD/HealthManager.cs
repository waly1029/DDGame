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

    private LifeManager lifeManager;

    private TimeManager timeManager;

    private LevelManager levelManager;

    // Use this for initialization
    void Start( ) {

        healthBar = transform.Find("Slider").GetComponent<Slider>( );

        playerHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");

        levelManager = FindObjectOfType<LevelManager>( );

        lifeManager = FindObjectOfType<LifeManager>( );

        timeManager = FindObjectOfType<TimeManager>( );

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

            lifeManager.TakeLife( );

            isDead = true;

            timeManager.RestTime( );

        }

        if ( playerHealth > maxPlayerHealth ) {

            playerHealth = maxPlayerHealth;

        }

    }

    public void DrawHealth( ) {

        healthBar.value = playerHealth;

    }
    
}
