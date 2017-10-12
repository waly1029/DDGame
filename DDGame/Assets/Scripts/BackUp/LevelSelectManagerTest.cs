using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManagerTest : MonoBehaviour {

    public GameObject[] locks;

    public string[] levelTags;

    public bool[] levelUnlocked;
    // Use this for initialization
    /*void Awake()
    {
        for (int i = 0; i < levelTags.Length; i++)
        {
            PlayerPrefs.SetInt(levelTags[i], i + 1);
            Debug.Log(PlayerPrefs.GetInt(levelTags[i]));
        }
    }*/

	void Start () {
        
        for(int i = 0; i < levelTags.Length; i++)
        {
            if(PlayerPrefs.GetInt(levelTags[i]) == null)
            {
                levelUnlocked[i] = false;
            } else if (PlayerPrefs.GetInt(levelTags[i]) == 0)
            {
                levelUnlocked[i] = false;
            }
            else
            {
                levelUnlocked[i] = true;
            }

            if (levelUnlocked[i])
            {
                locks[i].SetActive(false);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
