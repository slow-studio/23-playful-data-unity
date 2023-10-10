using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleBush : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        //creating and naming game object
        GameObject newGameObject = new GameObject("empty gameobject");
        //setting the position
        newGameObject.transform.position = new Vector2(5, 6);
        //setting parent
        newGameObject.transform.parent = transform;

        //getting a new prefab
        //creating, gtting position and parent
        GameObject prefabGObject = Instantiate(
            prefab,
            new Vector3(1, 1, 1),
            // quaternion creates a blank, empty set of rotation values to use on the prefab
            Quaternion.identity,
            transform
            );
        //naming
        prefabGObject.name = "prefab game object";

        Destroy(newGameObject, 2.0f);
        Destroy(prefabGObject, 4.0f);
    }

}
