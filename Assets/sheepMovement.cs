using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepMovement : MonoBehaviour
{
    public float speed = 8f;
    Vector2 tap, // where the person taps on the screen
            sheepPos,
            goal // where the sheep needs to go to
            ;
    bool moving;
    float minimumDistance = 0.1f;
    float sheepMoveDistance = 1.0f; // this is how much the sheep moves when asked to

    private void Update()
    {

        /* when click occurs, set a destination for the sheep */

        // check when click occurs
        if (Input.GetMouseButtonDown(0))
        { // "0":"Pressed left-click." 
            // get tap-position
            tap = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //get sheep's currnet position
            getSheepPos();
            // set destination
            setDestination();
            // instruct sheep that it can move
            moving = true;
            // make sheep move
            /*  if the sheep is still far from click-position */
            if (moving)
            {
                if ((goal - sheepPos).magnitude >= minimumDistance)
                {
                    moveSheep();
                }
            }
            // else sheep is not allowed to move
            else moving = false;

            void setDestination()
            {
                // set goal
                goal = (tap - sheepPos).normalized //direction
                        * sheepMoveDistance //magnitude
                        ;
                // Debug.Log(GetComponent<Transform>().position);
                Debug.Log(goal);
            }

            void getSheepPos()
            {
                // get sheep's position
                sheepPos = new Vector2(GetComponent<Transform>().position.x,
                                        GetComponent<Transform>().position.y
                                    );
            }

            /* sheep movement */

            // print the distance between sheep and click
            // Debug.Log( "distance between sheep and its goal = " + (goal - sheepPos).magnitude );

            // if the sheep is far enough, it can move toward the goal
            void moveSheep()
            {
                // set speed of movement
                // (make sure the sheep moves at the speed of the device-based on fps)
                float step = speed * Time.deltaTime;
                // let the sheep move
                transform.position = Vector2.MoveTowards(transform.position, goal, step);
            }
        }
    }
}
