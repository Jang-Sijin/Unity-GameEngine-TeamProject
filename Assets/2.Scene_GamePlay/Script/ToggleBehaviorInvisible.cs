using UnityEngine;
using System.Collections;
using MiscUtil.Conversion;


public class ToggleBehaviorInvisible : MonoBehaviour
{
    public Behaviour[] behavioursEnabledOnInvisble;
    public Behaviour[] behavioursDisabledOnInvisable;


    private void OnBecameInvisible()
    {        
        foreach (Behaviour bev in behavioursEnabledOnInvisble)
        {
            bev.enabled = true;
        }

        foreach (Behaviour bev in behavioursDisabledOnInvisable)
        {
            bev.enabled = false;
        }
    }
    
    private void OnBecameVisible()
    {
        foreach (Behaviour bev in behavioursEnabledOnInvisble)
        {
            bev.enabled = false;
        }

        foreach (Behaviour bev in behavioursDisabledOnInvisable)
        {
            bev.enabled = true;
        }
    }
}
