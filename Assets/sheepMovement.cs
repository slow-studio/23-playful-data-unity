using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepMovement : MonoBehaviour
{
    public float speed = 8f;
    Vector2 lastClickedPos, 
            finalPos ;
    bool moving;
    float minimumDistance = 1.0f;

    private void Update() {

        /* check when click occurs */
        if (Input.GetMouseButtonDown(0)) { // "0":"Pressed left-click." 
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            setDestination();
            moving = true;
        }

        /*  if the sheep is still far from click-position */
        
        // print the distance between sheep and click
        Debug.Log(((Vector2)transform.position - lastClickedPos).magnitude);

        // if the sheep is far enough
        if (moving && ((Vector2)transform.position - lastClickedPos).magnitude >= minimumDistance) {
            // make sure the sheep moves at the speed of the device-based on fps
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, finalPos, step);
        }
        // else: sheep is instructed that it can not move
        else {
            moving = false;
        }

        void setDestination() {
            //move towards the mouse click, but with some "randomness".
            int jitter = 3; // ~ sheepDirectionRandomness
            finalPos.x = Random.Range(lastClickedPos.x + jitter, lastClickedPos.x - jitter);
            finalPos.y = Random.Range(lastClickedPos.y + jitter, lastClickedPos.y - jitter);
        }
    }
}
