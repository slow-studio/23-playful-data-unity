using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovementMaster : MonoBehaviour
{
    public float speed = 8f;

   // private Rigidbody2D rigid_body;
    private Vector3 goal;
    private bool moving = false;

    private void Awake()
    {
     //   rigid_body = GetComponent<Rigidbody2D>();
        goal = transform.position;
    }
   
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            goal = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            goal.z = transform.position.z;

        }

        MoveSheep();

        moving = true;
    }

    private void MoveSheep()
    {
        if (moving)
            transform.position = Vector3.MoveTowards(transform.position, goal, Time.deltaTime);

        else
            moving = false;
    }

}
