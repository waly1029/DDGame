using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour {

    [SerializeField]
    private Text theText;

    private TimeModel timeModel;
    // Use this for initialization
    void Start ( ) {

        theText = transform.Find( "TimeCounter" ).GetComponent<Text>( );

		timeModel = FindObjectOfType<TimeModel> ( );

    }
	
	// Update is called once per frame
	void Update ( ) {
		
        DrawUI( );

	}

    void DrawUI( ) {

		theText.text = "" + Mathf.Round( timeModel.countingTime );

    }
}
