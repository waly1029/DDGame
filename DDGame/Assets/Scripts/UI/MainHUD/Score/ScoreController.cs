using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public static void AddPionts( int pointsToAdd ) {

        ScoreModel.score += pointsToAdd;

		PlayerPrefs.SetInt( "CurrentPlayerScores", ScoreModel.score );

    }

    /*public static void Reset( ) {

        score = 0;

        PlayerPrefs.SetInt( "CurrentPlayerScores", score );

    }*/

}
