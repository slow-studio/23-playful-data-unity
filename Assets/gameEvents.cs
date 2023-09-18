using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEvents : MonoBehaviour
{
    //making my own event system for game objects to subscribe to
    public static gameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onBushClick;
    public void bushClick()
    {
        //if action isnt null
        if (onBushClick != null)
            //execute the method
            onBushClick();
    }
}
