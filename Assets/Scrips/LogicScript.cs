using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public static LogicScript Instance;

    // Score stuff
    public int playerScore;

    // High Score stuff
    public int highScore; 
    
    // End UI stuff
    public UIManager UIManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    void Update()
    {
        if (!UIManager)
        {
            UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        }
    }

    // Increases score
    public void addScore( int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
    } 

    // Added to a button to restart
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playerScore = 0;
    }

    // Game Over UI appears when bird dies. -> to bird script
    public void gameOver()
    {
        UIManager.GetComponent<UIManager>().gameOver();

        if (playerScore > highScore)
        {
            highScore = playerScore;
            UIManager.NewHighScore.SetActive(true);
        }

    }

    // Added to a button to quit
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
