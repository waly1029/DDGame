using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour {

    [SerializeField]
    private Text theText;

	private LifeModel lifeModel;

    // Use this for initialization
    void Start ( ) {

        theText = transform.Find( "Text" ).GetComponent<Text>( );

		lifeModel = FindObjectOfType<LifeModel> ( );

    }
	
	// Update is called once per frame
	void Update ( ) {

        DrawUI( );

    }

    void DrawUI( ) {

		theText.text = "x " + lifeModel.lifeCounter;

    }
}
