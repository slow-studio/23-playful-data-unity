using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepPeek : MonoBehaviour
{
    SheepMovement sheepMovement;
    //[SerializeField] - can see it in the other scripts but can't be edited like in public declaration
    [SerializeField] GameObject sheep;

    // awake is called before start. Start is called before the first frame update
    void Awake()
    {
        //finding the gameobject refereced by the script sheepmovement
        sheepMovement = GameObject.Find("sheep").GetComponent<SheepMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
