using System.Collections;
using System.Collections.Generic;
using EnhancedUI;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private TMP_Text scoreLabel;
    
    void Start()
    {
        backButton.onClick.AddListener(ClicktoBackMenu);
        IEnumerator e = setScore();
        while (e.MoveNext()) ;
    }
    
    IEnumerator setScore()
    {
        int score = (int) Data.Get("playerScore");
        scoreLabel.text = score.ToString();
        
        WWWForm form = new WWWForm();
        form.AddField("access_token",(string) Data.Get("playerAccessToken"));
        form.AddField("score", score.ToString());

        UnityWebRequest www = UnityWebRequest.Post("https://night-at-cemetery.herokuapp.com/player/score", form);

        yield return www.SendWebRequest();
    }
    
    void ClicktoBackMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        backButton.onClick.RemoveListener(ClicktoBackMenu);
    }
}
