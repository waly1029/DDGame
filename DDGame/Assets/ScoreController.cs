using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public static void AddPionts( int pointsToAdd ) {

        ScoreManager.score += pointsToAdd;

        PlayerPrefs.SetInt( "CurrentPlayerScores", ScoreManager.score );

    }

    /*public static void Reset( ) {

        score = 0;

        PlayerPrefs.SetInt( "CurrentPlayerScores", score );

    }*/

}
