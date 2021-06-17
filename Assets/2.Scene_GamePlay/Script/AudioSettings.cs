using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    private static readonly string BackGroundPref = "BackGroundPref";
    private static readonly string EffectPref = "EffectPref";
    public Slider backGroundSlider, effectSlider;
    private float backgroundValue, effectValue;

    
    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        backgroundValue = PlayerPrefs.GetFloat(BackGroundPref);
        effectValue = PlayerPrefs.GetFloat(EffectPref);
        backGroundSlider.value = backgroundValue;
        effectSlider.value = effectValue;
    }
    
    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackGroundPref,backGroundSlider.value);
        PlayerPrefs.SetFloat(EffectPref,effectSlider.value);
    }

}
