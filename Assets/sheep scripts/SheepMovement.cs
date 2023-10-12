using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovement : MonoBehaviour
{
    public float speed = 8f;
    Vector2 tap, // where the person taps on the screen
            goal // where the sheep needs to go to
            ;
    public bool moving;
    private Animator animator;
    float minimumDistance = 0.1f;
    float sheepMoveDistance = 2f; // this is how much the sheep moves when asked to
    float sheepJitter = 0.25f; // when the sheep moves, it moves a bit randomly by this value


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
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

            animator.SetBool("walking", AnimateMove());
        }

        void setDestination() {

            // store the sheep's current position
            Vector2 sheepPos = getSheepPos();

            // this is the vector joining the sheep to the tap
            Vector2 sheepToTap = new Vector2(
                                (tap.x - sheepPos.x) // the vector.x between sheep and tap
                                    + (sheepJitter*Random.value) // add jitter
                                ,
                                (tap.y - sheepPos.y) // the vector.y between sheep and tap
                                    + (sheepJitter*Random.value) // add jitter
                                );

            // set goal for the sheep
            goal = sheepPos // the sheep starts from from where it currently stands
                    +   (
                            sheepToTap.normalized // starts moving in the direction of the tap
                            * 
                            // it would normally move "sheepMoveDistance", 
                            // but this Mathf.Min check ensures that it moves 
                            // less if the sheep is really close to the tap 
                            // (i.e., tap was closer than the sheep's usual sheepMoveDistance)
                            Mathf.Min(sheepToTap.magnitude, sheepMoveDistance) 
                        )
                    ;
        }

        /* sheep movement */

        // if the sheep is allowed to move 

        if (moving) {

            AnimateMove();

            // store the sheep's current position
            Vector2 sheepPos = getSheepPos();

            // print the distance between sheep and click
            Debug.Log( "distance between sheep and its goal = " + ( goal - sheepPos ).magnitude );

            /*  if the sheep is still far from click-position */

            // if the sheep is far enough, it can move toward the goal
            if ((goal - sheepPos).magnitude >= minimumDistance) {
                // set speed of movement
                // (make sure the sheep moves at the speed of the device-based on fps)
                float step = speed * Time.deltaTime;
                // let the sheep move
                transform.position = Vector2.MoveTowards(transform.position, goal, step);
            }
            // else: sheep is instructed that it can not move
            else moving = false;
        }

       
    }
    Vector2 getSheepPos()
    {
        return new Vector2(
                            GetComponent<Transform>().position.x,
                            GetComponent<Transform>().position.y
                            );
    }

    private bool AnimateMove()
    {
        return moving;
    }
}
