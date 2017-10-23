using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour {
    
	private LifeModel lifeModel;

	void Start( ) {
	
		lifeModel = FindObjectOfType<LifeModel> ();

	}
    public void GiveLife( ) {

		lifeModel.lifeCounter++;

		PlayerPrefs.SetInt( "PlayerCurrentLives", lifeModel.lifeCounter);

    }

    public void TakeLife( ) {

		lifeModel.lifeCounter--;

		PlayerPrefs.SetInt( "PlayerCurrentLives", lifeModel.lifeCounter);

    }

}
