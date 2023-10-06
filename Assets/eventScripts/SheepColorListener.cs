using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SheepColorListener : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    //the same event can trigger multiple listeners on different game objects.
    private UnityAction onTest;
    private void Awake()
    {
        onTest = new UnityAction(OnTest);
    }
    private void OnEnable()
    {
        EventManager.StartListening("Test", onTest);
        EventManager.StartListening("ChangeSheep", OnChangeSheep);
    }
    private void OnDisable()
    {
        EventManager.StopListening("Test", onTest);
        EventManager.StopListening("ChangeSheep", OnChangeSheep);
    }
    private void OnTest()
    {
        Debug.Log($"{gameObject.name} recieved an EXCITING test :D");
    }
    private void OnChangeSheep(object data)
    {
        //c color is the color version of the data being passed
        Color c = (Color)data;
        spriteRenderer.color = c;
    }
}
