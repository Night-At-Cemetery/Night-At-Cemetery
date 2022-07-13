using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingButtonBack : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip click;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(ClicktoBackMenu);
    }

    // Update is called once per frame
    void ClicktoBackMenu()
    {
        audioSource.PlayOneShot(click);
        SceneManager.LoadScene(3, LoadSceneMode.Single);
        button.onClick.RemoveListener(ClicktoBackMenu);

    }
}
