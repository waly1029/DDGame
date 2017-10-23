using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

    [SerializeField]
    private Text text;
    
    // Use this for initialization
    void Start ( ) {

        text = transform.Find( "ScoreCounter" ).GetComponent<Text>( );

    }
	
	// Update is called once per frame
	void Update ( ) {

        DrawUI( );

    }

    void DrawUI( ) {

        text.text = "" + ScoreManager.score;

    }
}
