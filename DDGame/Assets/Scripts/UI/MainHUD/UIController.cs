using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    

    public static void HurtPlayer( int damageToGive ) {

        HealthManager.playerHealth -= damageToGive;

        PlayerPrefs.SetInt("PlayerCurrentHealth", HealthManager.playerHealth);

    }

    static public void FullHealth( ) {

        HealthManager.playerHealth = PlayerPrefs.GetInt("PlayerMaxHealth");

        PlayerPrefs.SetInt("PlayerCurrentHealth", HealthManager.playerHealth);

    }

    static public void KillPlayer( ) {

        HealthManager.playerHealth = 0;

    }

}
