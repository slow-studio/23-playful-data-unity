using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delegateMeat : MonoBehaviour
{
    public delegate void meatDelegate();
    //public delegate bool ifMeat(int i);

    meatDelegate meatDelegateFunction;
    //ifMeat ifMeatFunction;

    private void Start()
    {
        //lambda expression for compactly defining a function
        //meatDelegateFunction = () => { Debug.Log(" testing testing")};

        //ifMeatFunction = (int i) => { return i < 5; };
        //Debug.Log(ifMeatFunction(1));
    }

    void OnMouseDown()
    {
        //calling the delegates to turn the sheep to meat
        meatDelegateFunction += turnMeat;
        meatDelegateFunction += calledMeat;

        if (meatDelegateFunction != null)
        {
            meatDelegateFunction();
        }
    }

    void calledMeat()
    {
        print("sheep will now become red");
    }

    void turnMeat()
    {
        //sheep turns red if it is currently white
        if (GetComponent<Renderer>().material.color == Color.white)
            GetComponent<Renderer>().material.color = Color.red;

        else
            GetComponent<Renderer>().material.color = Color.white;
    }

}