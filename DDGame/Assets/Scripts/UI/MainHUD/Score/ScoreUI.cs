using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

	[SerializeField]
	private Text text;

	void Start( ) {

		text = transform.Find( "ScoreCounter" ).GetComponent<Text>( );
	
	}

	void Update ( ) {

        DrawUI( );

    }

    void DrawUI( ) {

		text.text = "" + ScoreModel.score;

    }
}
