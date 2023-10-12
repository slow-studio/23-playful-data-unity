using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBush : MonoBehaviour
{
    public GameObject edibleBush;
    
    Vector3 oldPosition;
    public void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            spawnBush();
        }
    }

    public void spawnBush()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject bush = Instantiate(edibleBush, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
        bush.AddComponent<CircleCollider2D>();

        bush.tag = "edibleBush";

      //  Debug.Log("position of this temporary edible bush " + position);
    }
 }