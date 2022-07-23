using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private TMP_Text scoreLabel;
    [SerializeField] private GameObject[] health;

    public int score;
    public int currentHealth = 3;

    private void Awake()
    {
        setHealth(currentHealth);
    }

    void Start()
    {
        menuButton.onClick.AddListener(Menu);
        StartCoroutine(ChangeScore());
    }

    void Menu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void setHealth(int n)
    {
        if (n > 5)
        {
            return;
        }
        if (n <= 0)
        {
            Data.Set("playerScore",score);
            SceneManager.LoadScene(3, LoadSceneMode.Single);
            return;
        }
        int i = 1;
        foreach (var h in health)
        {
            if (i > n)
            {
                h.SetActive(false);
                continue;
            }

            h.SetActive(true);
            i++;
        }

        currentHealth = n;
    }

    private IEnumerator ChangeScore()
    {
        while (true)
        {
            yield return new WaitForSeconds((float) 0.1);
            score += 1;
            scoreLabel.text = score.ToString();
        }
    }
}