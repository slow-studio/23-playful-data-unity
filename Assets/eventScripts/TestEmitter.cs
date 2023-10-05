using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestEmitter : MonoBehaviour
{
    //this emitter code is to trigger events

    void Update()
    {
        //when mouse button is clicked, the event qill be triggered
        //recievers will now react to this with a callback function
        if (Input.GetMouseButtonDown(1))
            EventManager.TriggerEvent("Test");

        //adding another trigger 
        if (Input.GetKeyDown(KeyCode.Space))
            EventManager.TriggerEvent("ChangeColor", Color.gray);
    }
}
