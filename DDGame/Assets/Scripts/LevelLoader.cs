using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
//using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour {
    
    public bool playerInZone;

    public string levelToLoad;

    public int pointsToExit;

    public string levelTag;
    
	// Use this for initialization
	void Start () {
        playerInZone = false; 
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxisRaw("Vertical") > 0 && playerInZone && ScoreManager.score >= pointsToExit)
        {
            LoadLevel();
            //Application.LoadLevel(levelToLoad);
            //SceneManager.LoadScene(levelToLoad);
        }
	}

    public void LoadLevel()
    {
        PlayerPrefs.SetInt(levelTag, 1);
        //Application.LoadLevel(levelToLoad);
        SceneManager.LoadScene(levelToLoad);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = false;
        }
    }
}
