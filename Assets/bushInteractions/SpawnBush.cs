using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBush : MonoBehaviour
{
    public GameObject edibleBush;

    public void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject bush = Instantiate(edibleBush, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
            bush.AddComponent<CircleCollider2D>();
            bush.AddComponent<GetsEaten>();
            bush.tag = "edibleBush";
        }
    }
}