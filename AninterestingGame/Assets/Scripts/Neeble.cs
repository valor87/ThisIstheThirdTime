using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Neeble : MonoBehaviour
{
    bool ison1 = true;
    bool ison2 = true;
    bool ison3 = true;

    public bool seconddial;
    bool ButtonisOn = true;
    public bool ButonTwoIsOn = true;

    public float turnValuebuttonone;
    public float turnValuebuttontwo;
    public float turnValuebuttonthree;

    public GameObject seconddialGO;

    public Vector3 endrotation;
    public Vector3 endrotation2dial;

    Vector3 needleTransform;
    Vector3 needleTransform2;
    Vector3 tempvector;
    // Update is called once per frame
    void Update()
    {
        // Debug.Log(transform.eulerAngles);
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(transform.eulerAngles);
            Debug.Log(seconddialGO.transform.eulerAngles);
        }

        if (transform.eulerAngles == endrotation && !seconddial)
        {
            // code on finish goes here
            Debug.Log("you win");
        }

        else if (transform.eulerAngles == endrotation && seconddialGO.transform.eulerAngles == endrotation2dial && seconddialGO != null)
        {
            // win again
            Debug.Log("you win x2");
        }

        if (ButtonisOn)
        {
            transform.eulerAngles = needleTransform - tempvector;
           
        }
        if (seconddialGO != null && ButonTwoIsOn)
        {
            Debug.Log("ima bout to blow");
            seconddialGO.transform.eulerAngles = needleTransform2 - tempvector;

        }
    }
    public void SliderValuechange(float turn)
    {

        tempvector = new Vector3(0, 0, turn); // take the slider input and turns it into a rotate vector
    }

    IEnumerator Yabadaba(float degrees, bool isonTRUE)
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
                if (seconddialGO != null)
                {
                    needleTransform2 += Vector3.back;
                }

              
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
                if (seconddialGO != null)
                {
                    needleTransform2 -= Vector3.back;
                }
                yield return new WaitForSeconds(0.02f); // stop the corutine
                isonTRUE = true; // the button is on now
            }
        }
    }
    public void stopthedial()
    {
        ButtonisOn = false; // stops the dial from taking input
    }
    public void stoptheSeconddial()
    {
        ButonTwoIsOn = false; // stops the dial from taking input
    }
    public void ButtonPressed()
    {
        StartCoroutine(Yabadaba(turnValuebuttonone, ison1)); // starts the cortoutine
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
        StartCoroutine(Yabadaba(turnValuebuttontwo, ison2)); // starts the cortoutine
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
        StartCoroutine(Yabadaba(turnValuebuttonthree, ison3)); // starts the cortoutine
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
