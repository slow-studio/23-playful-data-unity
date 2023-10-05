using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    //list of all the events that are listening(recievers)
    private Dictionary<string, UnityEvent> eventDictionary;

    private static EventManager eventManager;
    //making a singleton to make sure instances dont happen multiple times and will not make duplicates
    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                    Debug.LogError("this is a second active event manager script on the game object");

                else
                    eventManager.Init();
            }

            return eventManager;
        }
    }

    //prepares dictionary so that null references dont come when things are added to it
    void Init()
    {
        if (eventDictionary == null)
            eventDictionary = new Dictionary<string, UnityEvent>();
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        //if the event to be called has a listener it reacts
        UnityEvent thisEvent = null;

        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            thisEvent.AddListener(listener);

        //if the event does not have a key, it is added to the event dictionary 
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if (eventManager == null) 
            return;
        UnityEvent thisEvent = null;

        if(instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            //removes listener if the key is already found in the library
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        //gets the event named from the library to invoke it
        UnityEvent thisEvent = null;

        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            thisEvent.Invoke();
    }
}
