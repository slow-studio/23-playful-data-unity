using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickEvent : MonoBehaviour
{
    public event EventHandler onBushClick; //passing the generic parameter through the event
    //<onBushClickEventArgs>
    // making a class that derives from event args to pass more info
    //public class onBushClickEventArgs : EventArgs
   // {
    //    public int spaceCount;
    //}

    private void Start()
    {
        //fires off the main event 
    }

    private void Update()
    {
        //checking to see if the trigger is made for the sheep to return
        //conditions : mouse click, sheep needs to not already be inside the bush
        //but for now, simplicity:
        if(Input.GetKeyDown(KeyCode.Space))
        onBushClick?.Invoke(this, EventArgs.Empty);
    }
}
