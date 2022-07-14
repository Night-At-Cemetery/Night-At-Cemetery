using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    [SerializeField] Slider slider;
    float valueslider;
    // Start is called before the first frame update
    void Start()
    {
        valueslider = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update()
    {
        valueslider=slider.value;
        Saveload();
    }
    void Saveload()
    {

        PlayerPrefs.SetFloat("volume", valueslider);
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        DontDestroyOnLoad(slider);
        Debug.Log(PlayerPrefs.GetFloat("volume")+" gia tri "+valueslider);
    }
    
}
