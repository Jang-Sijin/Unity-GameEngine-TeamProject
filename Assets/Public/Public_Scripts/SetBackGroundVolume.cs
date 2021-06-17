using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetBackGroundVolume : MonoBehaviour
{
    
    private static readonly string BackGroundPref = "BackGroundPref";
    public AudioMixer mixer;
    
    public void SetLevel(float sliderValue)
    {
        
        mixer.SetFloat("BackGoundVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(BackGroundPref,sliderValue);
    }
    
}
