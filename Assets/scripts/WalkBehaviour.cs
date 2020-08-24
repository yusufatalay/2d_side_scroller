using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float horizontalInput;
     
 
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(horizontalInput*speed*Time.deltaTime,0));
    }
}
