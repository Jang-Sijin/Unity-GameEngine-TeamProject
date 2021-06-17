using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class SetEffectVolume : MonoBehaviour
{
    private static readonly string EffectPref = "EffectPref";
    public AudioMixer mixer;
    
    public void SetLevel(float sliderValue)
    {
        
        mixer.SetFloat("EffectVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(EffectPref,sliderValue);
    }
}
