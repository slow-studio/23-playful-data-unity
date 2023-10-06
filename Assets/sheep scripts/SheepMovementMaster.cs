using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovementMaster : MonoBehaviour
{
    public float speed;
    public Vector2 DirectionToClick { get; private set; }
    public Vector2 sheepPos;

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D rigid_body;
    private Vector2 goal;
    private bool moving = false;

    private void Awake()
    {
        rigid_body = GetComponent<Rigidbody2D>();
        goal = transform.up;
    }
   
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //every frame update, new mouse clicks and direction of click to hseep is calculated
            Vector2 sheepToClickVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            DirectionToClick = sheepToClickVector.normalized;

            //goal = sheepToClickVector.magnitude;
        }

        //getting sheep position
        sheepPos = new Vector2(
                                GetComponent<Transform>().position.x,
                                GetComponent<Transform>().position.y
                                );

        //the logic for the sheep movement is here
        UpdateGoal();
        FaceGoal();
        SetVelocity();
        moving = true;
    }

    private void UpdateGoal()
    {
        if (moving)
            goal = DirectionToClick;

        else
            moving = false;
    }

    private void FaceGoal()
    {
        Quaternion goalRotation = Quaternion.LookRotation(transform.forward, goal);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, goalRotation, rotationSpeed * Time.deltaTime);

        rigid_body.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if (sheepPos == goal)
            rigid_body.velocity = Vector2.zero;
        //transform.position = Vector3.MoveTowards(transform.position, goal, speed);
        else
            rigid_body.velocity = transform.up * speed;
    }

}
