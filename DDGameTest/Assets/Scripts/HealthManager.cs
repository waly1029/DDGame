using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour {

    public int maxPlayerHealth;

    public static int playerHealth;

    //Text text;
    public Slider healthBar;

    private LevelManager levelManager;

    public bool isDead;

    private LifeManager lifeSystem;

    private TimeManager theTime;
	// Use this for initialization
	void Start () {
        //text = GetComponent<Text>();

        playerHealth = maxPlayerHealth;

        healthBar = GetComponent<Slider>();

        playerHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");

        levelManager = FindObjectOfType<LevelManager>();

        isDead = false;

        lifeSystem = FindObjectOfType<LifeManager>();

        theTime = FindObjectOfType<TimeManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHealth <= 0 && !isDead)
        {
            Debug.Log("Dead");
            playerHealth = 0;
            levelManager.RespawnPlayer();
            lifeSystem.TakeLife();
            isDead = true;
            theTime.RestTime();
        }

        if (playerHealth > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }
        //text.text = "" + playerHealth;
        healthBar.value = playerHealth;
	}

    public static void HurtPlayer(int damageToGive)
    {
        playerHealth -= damageToGive;

        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
    }

    public void FullHealth()
    {
        //playerHealth = maxPlayerHealth;
        playerHealth = PlayerPrefs.GetInt("PlayerMaxHealth");

        PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
    }

    public void KillPlayer()
    {
        playerHealth = 0;
    }
}
