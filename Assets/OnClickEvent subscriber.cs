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

   private void Testing_onBushClick(object sender, EventArgs e)
    {
        OnClickEvent onclickEvents = GetComponent<OnClickEvent>();
        //unsubscribes from the event trigger
        onclickEvents.onBushClick -= Testing_onBushClick;
        Debug.Log(" space was pressed ");
    }
}
