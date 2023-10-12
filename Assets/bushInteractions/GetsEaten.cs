using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetsEaten : MonoBehaviour
{
    
    public Vector3 position;
    public GameObject dirtRemains;

  private void OnMouseDown()
    {
        position = this.gameObject.transform.position;
        Destroy(this.gameObject);


        GameObject dirt = Instantiate(dirtRemains, position, Quaternion.identity);
    }

}
