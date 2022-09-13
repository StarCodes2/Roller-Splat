using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private Button startButton;
    private GameManager gameManager;
    public GameObject titleScreen;
    public Text buttonText;

    // Start is called before the first frame update
    void Start()
    {
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(StartGame);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartGame()
    {
        if(buttonText.text=="Restart")
        {
            SceneManager.LoadScene(0);
            return;
        }
        gameManager.isCompleted = false;
        titleScreen.gameObject.SetActive(false);
    }
}
