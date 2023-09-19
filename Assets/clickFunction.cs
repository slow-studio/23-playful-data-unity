using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickFunction : MonoBehaviour
{
    public SheepReturn sheepReturn;
    public bool go = false;

    private void OnMouseDown()
    {
        Debug.Log("bush clicked!");
        go = true;
    }
}