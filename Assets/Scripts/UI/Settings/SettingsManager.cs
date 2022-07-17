using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Button backButton;
    [SerializeField] Slider soundMusicSlider;
    [SerializeField] Slider soundEffectSlider;

    void Start()
    {
        backButton.onClick.AddListener(ClicktoBackMenu);

        soundMusicSlider.value = (int) Data.Get("settingsSoundMusic");
        soundEffectSlider.value = (int) Data.Get("settingsSoundEffect");
    }

    void ClicktoBackMenu()
    {
        Data.Set("settingsSoundMusic",(int) soundMusicSlider.value);
        Data.Set("settingsSoundEffect",(int) soundEffectSlider.value);
        Data.Save();

        SceneManager.LoadScene(0, LoadSceneMode.Single);
        backButton.onClick.RemoveListener(ClicktoBackMenu);
    }
}