using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepMovement : MonoBehaviour
{
    public float speed = 8f;
    Vector2 tap, // where the person taps on the screen
            goal // where the sheep needs to go to
            ;
    bool moving;
    float minimumDistance = 1.0f;

    private void Update() {

        /* when click occurs, set a destination for the sheep */

        // check when click occurs
        if (Input.GetMouseButtonDown(0)) { // "0":"Pressed left-click." 
            // get tap-position
            tap = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // set destination
            setDestination();
            // instruct sheep that it can move
            moving = true;
        }

        void setDestination() {
            //move towards the mouse click, but with some "randomness".
            int jitter = 3; // ~ sheepDirectionRandomness
            goal.x = Random.Range(tap.x + jitter, tap.x - jitter);
            goal.y = Random.Range(tap.y + jitter, tap.y - jitter);
        }

        /* sheep movement */

        // if the sheep is allowed to move 

        if (moving) {

            /*  if the sheep is still far from click-position */
            
            // print the distance between sheep and click
            Debug.Log(((Vector2)transform.position - tap).magnitude);

            // if the sheep is far enough
            if (((Vector2)transform.position - tap).magnitude >= minimumDistance) {
                // make sure the sheep moves at the speed of the device-based on fps
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, goal, step);
            }
            // else: sheep is instructed that it can not move
            else {
                moving = false;
            }
        }
    }
}
