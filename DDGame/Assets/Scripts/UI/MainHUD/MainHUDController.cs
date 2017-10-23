using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHUDController : MonoBehaviour {

    private HealthManager healthManager;

    //private ScoreManager scoreManager;

    //private LifeManager lifeManager;

    private TimeModel timeModel;

	// Use this for initialization
	void Start ( ) {

        healthManager = FindObjectOfType<HealthManager> ( );

        //scoreManager = FindObjectOfType<ScoreManager> ( );

        //lifeManager = FindObjectOfType<LifeManager> ( );

		timeModel = FindObjectOfType<TimeModel> ( );

    }
	
	// Update is called once per frame
	void Update ( ) {

        //lifeManager.DrawLife( );

        //scoreManager.DrawScore( );

        healthManager.DrawHealth( );

        //timeManager.DrawTimeCount( );

        healthManager.Health( );
        
        //scoreManager.Score( ); 

        //lifeManager.Life( );

		timeModel.TimeCount( );

	}

    

}
