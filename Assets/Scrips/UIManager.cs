using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text HSNumber;

    public GameObject GameOver;
    public GameObject NewHighScore;

    public Slider _musicSlider, _sfxSlider;

    public GameObject settingsMenu;
    public Button musicButton;
    public Button sfxButton;
    public Sprite musicSprite;
    public Sprite musicMuteSprite;
    public Sprite sfxSprite;
    public Sprite sfxMuteSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingsMenu.SetActive(false);
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
        AudioManager.Instance.PlaySFX("GameOver");

    }

    public void restartGame()
    {
        LogicScript.Instance.restartGame();
        AudioManager.Instance.PlaySFX("Button");
    }

    public void quitGame()
    {
        LogicScript.Instance.QuitGame();
        AudioManager.Instance.PlaySFX("Button");
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();

        if (AudioManager.Instance.musicSource.mute)
        {
            musicButton.image.sprite = musicMuteSprite;
        }
        else
        {
            musicButton.image.sprite = musicSprite;
        }
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();

        if (AudioManager.Instance.sfxSource.mute)
        {
            sfxButton.image.sprite = sfxMuteSprite;
        }
        else
        {
            sfxButton.image.sprite = sfxSprite;
        }
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
        
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }

    public void OpenMenu()
    {
        _musicSlider.value = AudioManager.Instance.musicSource.volume;
        _sfxSlider.value = AudioManager.Instance.sfxSource.volume;
        Debug.Log(AudioManager.Instance.musicSource.volume);
        Time.timeScale = 0f;
        settingsMenu.SetActive(true);

        if (AudioManager.Instance.musicSource.mute)
        {
            musicButton.image.sprite = musicMuteSprite;
        }
        else
        {
            musicButton.image.sprite = musicSprite;
        }

        if (AudioManager.Instance.sfxSource.mute)
        {
            sfxButton.image.sprite = sfxMuteSprite;
        }
        else
        {
            sfxButton.image.sprite = sfxSprite;
        }

    }

    public void CloseMenu()
    {
        Time.timeScale = 1f;
        settingsMenu.SetActive(false);
    }

}
