using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepReturn : MonoBehaviour
{
    public float speed = 8f;
    private void Start()
    {
        gameEvents.current.onBushClick += goBack;
    }

    private void goBack()
    {
        //find bush position
        //getBushPos();
        //Vector2 bushPos = getBushPos();
        Vector2 back = GameObject.Find("bush").transform.position.normalized;
        float step = speed * Time.deltaTime;
        // let the sheep move
        transform.position = Vector2.MoveTowards(transform.position, back, step);
    }

   // Vector2 getBushPos()
    //{
      //  return new Vector2(
      //                          GetComponent<Transform>().position.x,
       //                         GetComponent<Transform>().position.y
       //                         );
   // }

}
