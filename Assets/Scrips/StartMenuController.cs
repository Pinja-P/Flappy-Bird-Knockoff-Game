using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    public GameObject settingsMenu;
    public Button musicButton;
    public Button sfxButton;
    public Sprite musicSprite;
    public Sprite musicMuteSprite;
    public Sprite sfxSprite;
    public Sprite sfxMuteSprite;

    public void OnStartClick()
    {
        SceneManager.LoadScene("Game");
        AudioManager.Instance.PlaySFX("Button");
    }

    public void OnExitClick()
    {
        AudioManager.Instance.PlaySFX("Button");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
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
        settingsMenu.SetActive(false);
    }
}
