using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] private Button menu;
    
    void Start()
    {
        menu.onClick.AddListener(Menu);

    }

    void Menu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    void Update()
    {
        
    }
}
