using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delegateMeat : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public delegate void meatDelegate();
    //public delegate bool ifMeat(int i);
    public AudioSource sound;

    meatDelegate meatDelegateFunction;
    //ifMeat ifMeatFunction;

    private void Start()
    {
        //lambda expression for compactly defining a function
        //meatDelegateFunction = () => { Debug.Log(" testing testing")};

        //ifMeatFunction = (int i) => { return i < 5; };
        //Debug.Log(ifMeatFunction(1));

        sound = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        //calling the delegates to turn the sheep to meat
        meatDelegateFunction += turnIntoMeat;
        meatDelegateFunction += playBleat;

        //in case another function needs to be added
        // meatDelegateFunction += calledMeat; then write the function below

        if (meatDelegateFunction != null)
        {
            meatDelegateFunction();
        }
    }

    void turnIntoMeat()
    {
        //sheep turns red if it is currently white
        if (spriteRenderer.color == Color.white)
            spriteRenderer.color = Color.red;

        else
            spriteRenderer.color = Color.white;
    }

    void playBleat()
    {
        sound.Play();
        print("sound played");
    }
}
