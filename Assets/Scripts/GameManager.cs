using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    private GroundPiece[] allGroundPieces;
    public GameObject titleScreen;

    public bool isCompleted;

    // Start is called before the first frame update
    void Start()
    {
        SetupNewLevel();
    }

    private void Update()
    {
        if (titleScreen.gameObject.activeSelf)
        {
            isCompleted = true;
        }
    }

    private void SetupNewLevel()
    {
        allGroundPieces = FindObjectsOfType<GroundPiece>();
    }

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        } else if (singleton != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        SetupNewLevel();
    }

    public void CheckComplete()
    {
        bool isFinished = true;

        for(int i = 0; i < allGroundPieces.Length; i++)
        {
            if(allGroundPieces[i].isColored == false)
            {
                isFinished = false;
                break;
            }
        }

        if(isFinished)
        {
            //NextLevel
            NextLevel();
        }
    }

    private void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            isCompleted = true;
            titleScreen.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            isCompleted = false;
        }
    }
}
