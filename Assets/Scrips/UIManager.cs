using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text HSNumber;

    public GameObject GameOver;
    public GameObject NewHighScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HSNumber.text = " " + LogicScript.Instance.highScore;
        scoreText.text = " " + LogicScript.Instance.playerScore;

    }

    // Game Over UI appears when bird dies. -> to bird script
    public void gameOver()
    {
        GameOver.SetActive(true);

    }

    public void restartGame()
    {
        LogicScript.Instance.restartGame();
    }

    public void quitGame()
    {
        LogicScript.Instance.QuitGame();
    }
}
