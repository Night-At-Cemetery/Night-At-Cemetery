using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button NewGameButton;
    [SerializeField] Button SettingButton;
    [SerializeField] Button QuitButton;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip click;
    // Start is called before the first frame update
    void Start()
    {
        NewGameButton.onClick.AddListener(clickNewGame);
        SettingButton.onClick.AddListener(clicktoSetting);
        QuitButton.onClick.AddListener(clicktoQuit);
        audioSource.Play();
    }

    // Update is called once per frame
    void clickNewGame()
    {
        audioSource.PlayOneShot(click);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        NewGameButton.onClick.RemoveListener(clickNewGame);
       
    }
    void clicktoSetting()
    {
        audioSource.PlayOneShot(click);
        SceneManager.LoadScene(2, LoadSceneMode.Single);
        SettingButton.onClick.RemoveListener(clicktoSetting);
        
    }
    void clicktoQuit()
    {
        audioSource.PlayOneShot(click);
        Application.Quit();
        QuitButton.onClick.RemoveListener(clicktoQuit);
        
    }
   
}
