using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickEvent : MonoBehaviour
{
    public event EventHandler onBushClick;

    private void Start()
    {
        onBushClick += Testing_onBushClick;
    }
    //defining a function that will recieve this event
    private void Testing_onBushClick(object sender, EventArgs e)
    {
        Debug.Log(" space was pressed ");
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
