using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Neeble : MonoBehaviour
{
    bool ison1 = true;
    bool ison2 = true;
    bool ison3 = true;
    public bool ButtonisOn;
    public float turnValue;
    public GameObject endpos;
    Vector3 needleTransform;
    Vector3 tempvector;
    // Update is called once per frame
    void Update()
    {
       
            if (transform.eulerAngles == new Vector3(0, 0, 260))
            {
               // code on finish goes here
            }
        if (ButtonisOn)
        {
            transform.eulerAngles = needleTransform - tempvector;
        }
        }
    public void SliderValuechange(float turn)
    {
        
        tempvector = new Vector3(0,0, turn); // take the slider input and turns it into a rotate vector
    }
   
    IEnumerator Yabadaba (float degrees, bool isonTRUE)
    {
        Vector3 rotation = transform.eulerAngles;
        
        if (isonTRUE) // runs if the button is on
        {
            int temp = 0; // set the degrees to zero
            while (temp != degrees)
            {
                temp++; // temp increases
                rotation = transform.eulerAngles;
                needleTransform += Vector3.back; // gives the movement to the object
                yield return new WaitForSeconds(0.02f); // stop the corutine
                isonTRUE = false; // the button is on now
            }
        }
        else
        {
            int temp = 0; // set the degrees to zero
            while (temp != degrees)
            {
                temp++; // temp increases
                rotation = transform.eulerAngles;  
                needleTransform -= Vector3.back; // gives the movement to the object
                yield return new WaitForSeconds(0.02f); // stop the corutine
                isonTRUE = true; // the button is on now
            }
        }
    }
    public void stopthedial()
    {
        ButtonisOn = false; // stops the dial from taking input
    }
    public void ButtonPressed()
    {
        StartCoroutine(Yabadaba(turnValue, ison1)); // starts the cortoutine
        if (ison1)
        {
            ison1 = false;
        }
        else
        {
            ison1 = true;
        }
    }
    public void ButtonPressed2()
    {
        StartCoroutine(Yabadaba(turnValue, ison2)); // starts the cortoutine
        if (ison2)
        {
            ison2 = false;
        }
        else
        {
            ison2 = true;
        }
    }
    public void ButtonPressed3()
    {
        StartCoroutine(Yabadaba(turnValue, ison3)); // starts the cortoutine
        if (ison3)
        {
            ison3 = false;
        }
        else
        {
            ison3 = true;
        }
    }
}
