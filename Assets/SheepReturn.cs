using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepReturn : MonoBehaviour
{
    float speed = 8f;
    private Vector2 bush;

    SheepReturn sheepReturn;
    private void Start()
    {
    }

    private void Update()
    {

        // makes teh sheep return to the bush 
        Debug.Log("sheep recieved order to go back");
        float step = speed * Time.deltaTime;

        //Vector2 bushPos = getBushPos();
        bush = new Vector2(0.0f, 0.0f);
        transform.position = Vector2.MoveTowards(transform.position, bush, step);
        //transform.position = Vector2.MoveTowards(transform.position, bush, step);
    }


    // private Vector2 getBushPos()
    //{
        //get the Input from Horizontal axis
        //float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        //float verticalInput = Input.GetAxis("Vertical");

       //float step = speed * Time.deltaTime;

       // Vector2 direction = new Vector2(horizontalInput * step, verticalInput * step);

    }
       

