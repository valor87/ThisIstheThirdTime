using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public bool idleright;
    public bool idleleft;
    public bool idledown;
    public bool idleup;

    public float speed;
    public bool canMove = true;
    Rigidbody2D Rb;
    Vector2 tempx;
    Vector2 tempy;
    public Animator PA;
    public float speedani;
    public float speedani2;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
         
    }
    // Update is called once per frame
    void Update()
    {

        //Debug.Log(directionx);
        
        if (canMove)
        {
            
         
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
            //speed = 5;
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
       
        if (Input.GetKey("d"))
        {
            idleright = idlechange(1);
            speedani = 1;
            
        }
        else if (Input.GetKey("w"))
        {
            idleup = idlechange(1);
            speedani2 = 1;
        }
        else if (Input.GetKey("a"))
        {
            idleleft = idlechange(1);
            speedani = -1;
        }
    
        else if (Input.GetKey("s"))
        {
            idledown = idlechange(1);
            speedani2 = -1;
        }
        else
        {
            speedani = 0;
            speedani2 = 0;
            idleup = idlechange(0); idledown = idlechange(0); idleleft = idlechange(0); idleright = idlechange(0);
        }
        Debug.Log(speedani);
        PA.SetFloat("Directionx", speedani);
        PA.SetFloat("Directiony", speedani2);
    }

}


