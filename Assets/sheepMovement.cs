using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepMovement : MonoBehaviour
{
    public float speed = 8f;
    Vector2 lastClickedPos;
    Vector2 finalPos;
    bool moving;

    private void Update()
    {
        // checking if the click occurs
        if (Input.GetMouseButtonDown(0))
        {
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            setDestination();
            moving = true;
        }
        //if sheep not very close to click
        Debug.Log(((Vector2)transform.position - lastClickedPos).magnitude);
        if (moving && ((Vector2)transform.position - lastClickedPos).magnitude >= 1)
        {
            // step is to make sure the sheep moves at the speed of the device-based on fps
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, finalPos, step);

        }
        else //do not move
        {
            moving = false;
        }
        void setDestination()
            {
             //move towards the mouse click
             int incrementValue = 3;
             finalPos.x = Random.Range(lastClickedPos.x + incrementValue, lastClickedPos.x - incrementValue);
             finalPos.y = Random.Range(lastClickedPos.y + incrementValue, lastClickedPos.y - incrementValue);
            }
    }
}
