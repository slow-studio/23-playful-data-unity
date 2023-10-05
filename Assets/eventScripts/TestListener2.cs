using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestListener2 : MonoBehaviour
{
    //the same event can trigger multiple listeners on different game objects.
    private UnityAction onTest;
    private void Awake()
    {
        onTest = new UnityAction(OnTest);
    }
    private void OnEnable()
    {
        EventManager.StartListening("Test", onTest);
    }
    private void OnDisable()
    {
        EventManager.StopListening("Test", onTest);
    }
    private void OnTest()
    {
        Debug.Log($"{gameObject.name} recieved an EXCITING test :D");
    }
}
