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
    // Start is called before the first frame update
    void Start()
    {
        NewGameButton.onClick.AddListener(clickNewGame);
        SettingButton.onClick.AddListener(clicktoSetting);
        QuitButton.onClick.AddListener(clicktoQuit);
    }

    // Update is called once per frame
    void clickNewGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        NewGameButton.onClick.RemoveListener(clickNewGame);
    }
    void clicktoSetting()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
        SettingButton.onClick.RemoveListener(clicktoSetting);
    }
    void clicktoQuit()
    {
        Application.Quit();
        QuitButton.onClick.RemoveListener(clicktoQuit);
    }
}
