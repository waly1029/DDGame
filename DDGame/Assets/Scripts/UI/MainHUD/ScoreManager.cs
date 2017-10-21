using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {

    public static int score;

    [SerializeField]
    private Text text;

    void Start( ) {

        text = transform.Find( "ScoreCounter" ).GetComponent<Text>( );

        score = PlayerPrefs.GetInt( "CurrentPlayerScores" );

    }

    // Update is called once per frame
    void Update( ) {

    }

    public void Score( ) {

        if (score < 0) {

            score = 0;

        }

    }

    public void DrawScore( ) {

        text.text = "" + score;

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
