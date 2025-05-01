using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public bool idleright;
    public bool idleleft;
    public bool idledown;
    public bool idleup;

    public float speed = 5;
    public bool canMove = true;

    public Animator PA;
    // Update is called once per frame
    void Update()
    {
        
        
        if (canMove)
        {
            PA.SetBool("IdleLeft", idleleft);
            PA.SetBool("IdleRight", idleright);
            PA.SetBool("IdleUp", idleup);
            PA.SetBool("IdleDown", idledown);

            transform.position += Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.position += Vector3.up * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        }

        changeanimation();

        if (Input.GetKey("left shift"))
        {
            speed = 7;
        }
        else
        {
            speed = 5;
        }

    }
    bool idlechange(int i)
    {
        if (i == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void changeanimation()
    {
        if (Input.GetKeyDown("d"))
        {
            idleright = idlechange(1);
        }
        else if (Input.GetKeyDown("w"))
        {
            idleup = idlechange(1);
        }
        else if (Input.GetKeyDown("a"))
        {
            idleleft = idlechange(1);
        }
        else if (Input.GetKeyDown("s"))
        {
            idledown = idlechange(1);
        }
        else
        {
           idleup = idlechange(0); idledown = idlechange(0); idleleft = idlechange(0); idleright = idlechange(0);
        }
    }

}


