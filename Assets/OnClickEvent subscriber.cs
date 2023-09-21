using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickEventsubscriber : MonoBehaviour
{
    private void Start()
    {
        //calling the main event trigger
        OnClickEvent onclickEvents = GetComponent<OnClickEvent>();
        //subscribes to the called event
        onclickEvents.onBushClick += Testing_onBushClick;
    }

   private void Testing_onBushClick(object sender, OnClickEvent.onBushClickEventArgs e)
    {
        Debug.Log(" space " + e.spaceCount + " was pressed ");
        //unsubscribes from the event trigger
        //OnClickEvent onclickEvents = GetComponent<OnClickEvent>();
        //onclickEvents.onBushClick -= Testing_onBushClick;
    }
}
