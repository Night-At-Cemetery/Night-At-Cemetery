using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using EnhancedUI;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject playerName;
    [SerializeField] private Button playerNameClose;
    [SerializeField] private GameObject playerNameInput;
    [SerializeField] private InputField playerNameInputValue;
    [SerializeField] private GameObject playerNameSpiner;
    [SerializeField] private TMP_Text playerNameNotice;
    [SerializeField] private Button playerNameSave;
    
    [SerializeField] private Button playerNameChange;

    [SerializeField] private TMP_Text playerNameLabel;

    private void Awake()
    {
        playerNameSave.onClick.AddListener(PlayerNameSave);
        playerNameChange.onClick.AddListener(PlayerNameChange);
        playerNameClose.onClick.AddListener(PlayerNameClose);

        ///////
        
        if (SetPlayer())
        {
            playerName.SetActive(false);
        }
        else
        {
            playerNameNotice.text = "";
            playerNameInputValue.text = "";
            
            playerNameInput.SetActive(true);
            playerNameClose.gameObject.SetActive(false);
            playerNameSpiner.SetActive(false);
            playerName.SetActive(true);
        }
    }

    void PlayerNameSave()
    {
        if (playerNameInputValue.text == "")
        {
            playerNameNotice.text = "Please enter something";
            return;
        }
        
        playerNameInput.SetActive(false);
        playerNameSpiner.SetActive(true);
        
        IEnumerator e = NewPlayer(playerNameInputValue.text);
        while (e.MoveNext()) ;

        if (SetPlayer())
        {
            playerName.SetActive(false);
            return;
        }
        
        playerNameSpiner.SetActive(false);
        playerNameInput.SetActive(true);
    }

    void PlayerNameClose()
    {
        playerName.SetActive(false);
    }
    
    void PlayerNameChange()
    {
        playerNameNotice.text = "";
        playerNameInputValue.text = "";

        playerNameInput.SetActive(true);
        playerNameClose.gameObject.SetActive(true);
        playerNameSpiner.SetActive(false);
        playerName.SetActive(true);
    }
    
    IEnumerator NewPlayer(string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        UnityWebRequest www = UnityWebRequest.Post("https://night-at-cemetery.herokuapp.com/player", form);

        yield return www.SendWebRequest();

        while (!www.isDone)
            yield return true;

        if (www.isNetworkError || www.isHttpError)
        {
        }
        else
        {
            JObject result = JObject.Parse(www.downloadHandler.text);
            if (result["error"] == null)
            {
                Data.Set("playerID",(int) result["id"]);
                Data.Set("playerName",(string) result["name"]);
                Data.Set("playerAccessToken",(string) result["access_token"]);
                Data.Save();
            }
            else
            {
                playerNameNotice.text = "Error";
            }
        }
    }

    bool SetPlayer()
    {
        int playerID = (int) Data.Get("playerID");
        if (playerID == 0)
        {
            return false;
        }

        playerNameLabel.text = (string) Data.Get("playerName") +"#"+ Data.Get("playerID");

        return true;
    }
    
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
