using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public bool canMove = true;
   
    // Update is called once per frame
    void Update()
    {
        if (canMove) {
            transform.position += Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.position += Vector3.up * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        }

        if (Input.GetKey("left shift"))
        {
            speed = 7;
        }
        else
        {
            speed = 5;
        }

        }
}
