using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetsEaten : MonoBehaviour
{
  private void OnTriggerEnter()
    {
        Debug.Log("sheep has triggered an event by touching bush");
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision collision)
    {
        Debug.Log("collision has been triggered");
    }
}
