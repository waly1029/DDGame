using UnityEngine;
using System.Collections;

public class CoinBlock : MonoBehaviour {
    

    public int scoreEachTime;

    public int blockLives;
	// Use this for initialization
	void Start () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.name == "PlayerHead" )
        {
            ScoreManager.AddPionts(scoreEachTime);
            Debug.Log("HeadTouched");
            blockLives--;
        }

        if (blockLives <= 0)
        {
            Destroy(gameObject);
        }
    }
}
