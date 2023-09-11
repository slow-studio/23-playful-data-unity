using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class becomeMeat : MonoBehaviour
{
  
  
     private void OnMouseDown()
     {
     Renderer renderer = GetComponent<Renderer>();
     renderer.material.color = new Color(1, 0, 1);
     }

}
