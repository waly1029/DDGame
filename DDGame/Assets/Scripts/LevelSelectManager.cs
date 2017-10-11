using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelSelectManager : MonoBehaviour {

    public const int MAX_LEVEL_LOCKS = 8;

    [SerializeField]
    private GameObject[] locks;
    
    private string locksNum = "";

    public string[] levelTags;

    public bool[] levelUnlocked;

    public int positionSelector;

    public string[] levelName;

    public float moveSpeed;

    private bool isPressed;

    public float distanceBelowLock;
    
    public bool touchMode;

    
    // Use this for initialization
    void Start () {

        locks = new GameObject[ MAX_LEVEL_LOCKS ];

        FindLevelLocks( );

        for (int i = 0; i < levelTags.Length; i++)
        {
            if (PlayerPrefs.GetInt(levelTags[i]) == null)
            {
                levelUnlocked[i] = false;
            } else if (PlayerPrefs.GetInt(levelTags[i]) == 0)
            {
                levelUnlocked[i] = false;
            }
            else if(PlayerPrefs.GetInt(levelTags[i]) == 1)
            {
                levelUnlocked[i] = true;
            }

            if (levelUnlocked[i] == true)
            {
                locks[i].SetActive(false);
            }
        }

        positionSelector = PlayerPrefs.GetInt("PlayerLevelSelectPosition");
        
        transform.position = locks[positionSelector].transform.position + new Vector3(0, distanceBelowLock, 0);

	}
	
	// Update is called once per frame
	void Update () {

        if (!isPressed)
        {
            if (Input.GetAxis("Horizontal") > 0.25f)
            {
                Debug.Log(">>");
                positionSelector += 1;
                isPressed = true;
            }

            if (Input.GetAxis("Horizontal") < -0.25f)
            {
                Debug.Log("<<");
                positionSelector -= 1;
                isPressed = true;
            }

            if (positionSelector >= levelTags.Length)
            {
                positionSelector = levelTags.Length - 1;
            }

            if (positionSelector < 0)
            {
                positionSelector = 0;
            }

        }

        if (isPressed)
        {
            if (Input.GetAxis("Horizontal") < 0.25f && Input.GetAxis("Horizontal") > -0.25f)
            {
                isPressed = false;
            }

        }

        transform.position = Vector3.MoveTowards(transform.position, locks[positionSelector].transform.position + new Vector3(0, distanceBelowLock, 0), moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            if (levelUnlocked[positionSelector] && !touchMode)
            {
                PlayerPrefs.SetInt("PlayerLevelSelectPosition", positionSelector);
                //Application.LoadLevel(levelName[positionSelector]);
                SceneManager.LoadScene(levelName[positionSelector]);
            }
        }
	}

     private void FindLevelLocks( ) {

        for( int i = 0; i < MAX_LEVEL_LOCKS; i++ ) {
            
            locksNum = "Level_Select_Lock_0" + ( i + 1 );

            locks[ i ] = GameObject.Find( locksNum );

            Debug.Log(locksNum);

        }
    }
}
