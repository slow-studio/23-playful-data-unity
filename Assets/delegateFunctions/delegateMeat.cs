using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delegateMeat : MonoBehaviour
{
    public delegate void meatDelegate();
    public delegate bool ifMeat(int i);

    private meatDelegate meatDelegateFunction;
    private ifMeat ifMeatFunction;

    private void Start()
    {
        //lambda expression for compactly defining a function
        //meatDelegateFunction = () => { Debug.Log(" testing testing")};

        ifMeatFunction = (int i) => { return i < 5; };
        Debug.Log(ifMeatFunction(1));
    }
}
