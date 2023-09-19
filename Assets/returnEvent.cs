using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnEvent : MonoBehaviour
{
    public event EventHandler onBushClick;

    private void Start()
    {
        
    }

    private void Update()
    {
        //checking to see if the trigger is made for the sheep to return
        //conditions : mouse click, sheep needs to not already be inside the bush
        //but for now, simplicity:
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (onBushClick != null)
            onBushClick(this, EventArgs.Empty);
        }
    }
}
