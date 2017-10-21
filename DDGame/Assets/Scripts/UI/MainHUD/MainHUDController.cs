using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHUDController : MonoBehaviour {

    private HealthManager healthManager;

    private ScoreManager scoreManager;

    private LifeManager lifeManager;

    private TimeManager timeManager;

	// Use this for initialization
	void Start ( ) {

        healthManager = FindObjectOfType<HealthManager> ( );

        scoreManager = FindObjectOfType<ScoreManager> ( );

        lifeManager = FindObjectOfType<LifeManager> ( );

        timeManager = FindObjectOfType<TimeManager> ( );

    }
	
	// Update is called once per frame
	void Update ( ) {

        lifeManager.DrawLife( );

        scoreManager.DrawScore( );

        healthManager.DrawHealth( );

        timeManager.DrawTimeCount( );

        healthManager.Health( );
        
        scoreManager.Score( ); 

        lifeManager.Life( );

        timeManager.TimeCount( );

	}

    

}
