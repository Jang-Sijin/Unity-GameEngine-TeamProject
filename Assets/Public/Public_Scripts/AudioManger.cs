using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManger : MonoBehaviour
{
    
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackGroundPref = "BackGroundPref";
    private static readonly string EffectPref = "EffectPref";
    private int firstplayInt;
    public Slider backGroundSlider, effectSlider;
    private float backgroundValue, effectValue;
    
    // Start is called before the first frame update
    void Start()
    {
        firstplayInt = PlayerPrefs.GetInt(FirstPlay);
        if (firstplayInt == 0)
        {
            backgroundValue = .75f;
            effectValue = .25f;

            backGroundSlider.value = backgroundValue;
            effectSlider.value = effectValue;
            
            PlayerPrefs.SetFloat(BackGroundPref,backgroundValue);
            PlayerPrefs.SetFloat(EffectPref,effectValue);
            PlayerPrefs.SetInt(FirstPlay,-1);
        }
        else
        {
            backgroundValue = PlayerPrefs.GetFloat(BackGroundPref);
            effectValue = PlayerPrefs.GetFloat(EffectPref);
            backGroundSlider.value = backgroundValue;
            effectSlider.value = effectValue;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackGroundPref,backGroundSlider.value);
        PlayerPrefs.SetFloat(EffectPref,effectSlider.value);
    }

    void OnApplicationFocus(bool isFocus)
    {
        if (!isFocus)
        {
            SaveSoundSettings();
        }
    }

}
