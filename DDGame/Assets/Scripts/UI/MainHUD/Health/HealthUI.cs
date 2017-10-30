using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

	[SerializeField]
	private Slider healthBar;

	void Start( ) {
	
		healthBar = transform.Find( "Slider" ).GetComponent<Slider>( );

	}

	void Update( ) {
	
		DrawHealthBar( );

	}

	void DrawHealthBar( ) {
	
		healthBar.value = HealthModel.playerHealth;

	}

}
