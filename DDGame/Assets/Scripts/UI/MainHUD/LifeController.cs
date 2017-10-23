using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour {
    
    private LifeManager lifeManager;

    void Start( ) {

        lifeManager = FindObjectOfType<LifeManager> ( );

    }

    public void GiveLife( ) {

        lifeManager.lifeCounter++;

        PlayerPrefs.SetInt( "PlayerCurrentLives", lifeManager.lifeCounter);

    }

    public void TakeLife( ) {

        lifeManager.lifeCounter--;

        PlayerPrefs.SetInt( "PlayerCurrentLives", lifeManager.lifeCounter);

    }

}
