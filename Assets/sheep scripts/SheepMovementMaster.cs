using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovementMaster : MonoBehaviour
{
    public float speed;
    public Vector2 DirectionToClick { get; private set; }

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D rigid_body;
    private Vector2 goal;

    private void Awake()
    {
        rigid_body = GetComponent<Rigidbody2D>();
        //goal = transform.up;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //every frame update, new mouse clicks and direction of click to hseep is calculated
            Vector2 sheepToClickVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            DirectionToClick = sheepToClickVector.normalized;

            // goal = sheepToClickVector.magnitude;
        }
    }
    private void FixedUpdate()
    {
        //the logic for the sheep movement is here
        UpdateGoal();
        FaceGoal();
        SetVelocity();
    }

    private void UpdateGoal()
    {
        goal = DirectionToClick;
    }

    private void FaceGoal()
    {
        Quaternion goalRotation = Quaternion.LookRotation(transform.forward, goal);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, goalRotation, rotationSpeed * Time.deltaTime);

        rigid_body.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        rigid_body.velocity = transform.up * speed;
    }

}
