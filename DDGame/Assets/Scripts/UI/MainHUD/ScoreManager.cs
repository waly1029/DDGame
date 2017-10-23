using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {

    public static int score;

    void Start( ) {

        score = PlayerPrefs.GetInt( "CurrentPlayerScores" );

    }

    // Update is called once per frame
    void Update( ) {

        RestScore( );

    }

    void RestScore( ) {
        
        if ( score < 0 ) {

            score = 0;

        }

    }
    /*public static void AddPionts( int pointsToAdd ) {

        score += pointsToAdd;

        PlayerPrefs.SetInt( "CurrentPlayerScores", score );

    }*/

    /*public static void Reset( ) {

        score = 0;

        PlayerPrefs.SetInt( "CurrentPlayerScores", score );

    }*/

}
