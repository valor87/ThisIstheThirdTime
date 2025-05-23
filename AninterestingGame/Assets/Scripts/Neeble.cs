using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Neeble : MonoBehaviour
{
    bool ison1 = true;
    bool ison2 = true;
    bool ison3 = true;
    bool isrunning = false;
    public bool puzzledone = false;
    public bool seconddial;
    bool ButtonisOn = true;
    public bool ButonTwoIsOn = true;

    public float turnValuebuttonone;
    public float turnValuebuttontwo;
    public float turnValuebuttonthree;

    public GameObject canvus;
    public GameObject seconddialGO;
    public GameObject slider;
    public GameObject GreenLight;
    public Sprite LitGreenLight;

    public List<Sprite> listofbuttons;
    public List<GameObject> buttons;

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

            //Debug.Log(seconddialGO.transform.eulerAngles);
        }

        //if (transform.eulerAngles == endrotation && !seconddial)
        //{
        //    // code on finish goes here
        //    Debug.Log("you win");
        //}

        else if (seconddialGO != null && transform.eulerAngles == endrotation && seconddialGO.transform.eulerAngles == endrotation2dial)
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

            seconddialGO.transform.eulerAngles = needleTransform2 - tempvector;

        }
    }
    public void SliderValuechange(float turn)
    {
        checkifcorrect();

        tempvector = new Vector3(0, 0, turn); // take the slider input and turns it into a rotate vector
    }
    IEnumerator closepuzzle()
    {
        yield return new WaitForSeconds(2);
        canvus.SetActive(false);
        puzzledone = true;
    }
    IEnumerator Yabadaba(float degrees, bool isonTRUE)
    {
        isrunning = true;
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

        isrunning = false;
        yield return new WaitForSeconds(2);

        checkifcorrect();
    }
    public void stopthedial()
    {
        ButtonisOn = false; // stops the dial from taking input
        buttons[3].GetComponent<Image>().sprite = listofbuttons[3];
    }
    public void stoptheSeconddial()
    {
        ButonTwoIsOn = false; // stops the dial from taking input
        buttons[4].GetComponent<Image>().sprite = listofbuttons[3];
    }
    public void ButtonPressed()
    {
        if (!isrunning)
        {
            StartCoroutine(Yabadaba(turnValuebuttonone, ison1)); // starts the cortoutine
            if (ison1)
            {
                ison1 = false;
                buttons[0].GetComponent<Image>().sprite = listofbuttons[1];
            }
            else
            {
                ison1 = true;
                buttons[0].GetComponent<Image>().sprite = listofbuttons[0];
            }
        }
    }
    public void ButtonPressed2()
    {
        if (!isrunning)
        {
            StartCoroutine(Yabadaba(turnValuebuttontwo, ison2)); // starts the cortoutine
            if (ison2)
            {
                ison2 = false;
                buttons[1].GetComponent<Image>().sprite = listofbuttons[1];
            }
            else
            {
                ison2 = true;
                buttons[1].GetComponent<Image>().sprite = listofbuttons[0];
            }
        }
    }
    public void ButtonPressed3()
    {
        if (!isrunning)
        {
            StartCoroutine(Yabadaba(turnValuebuttonthree, ison3)); // starts the cortoutine
            if (ison3)
            {
                ison3 = false;
                buttons[2].GetComponent<Image>().sprite = listofbuttons[1];
            }
            else
            {
                ison3 = true;
                buttons[2].GetComponent<Image>().sprite = listofbuttons[0];
            }
        }
    }

    public void GameStateReset()
    {
        StopAllCoroutines();
        ison1 = true;
        ison2 = true;
        ison3 = true;
        isrunning = false;
        if (buttons[3] != null)
        {
            ButtonisOn = true; // starts the dial from taking input
            buttons[3].GetComponent<Image>().sprite = listofbuttons[2];
        }
        if (buttons[4] != null)
        {
            ButonTwoIsOn = true; // staarts the dial from taking input
            buttons[4].GetComponent<Image>().sprite = listofbuttons[2];
        }
        buttons[0].GetComponent<Image>().sprite = listofbuttons[0];
        buttons[1].GetComponent<Image>().sprite = listofbuttons[0];
        buttons[2].GetComponent<Image>().sprite = listofbuttons[0];

        slider.GetComponent<Slider>().value = 0;
        needleTransform = new Vector3(0, 0, 0);
        needleTransform2 = new Vector3(0, 0, 0);
    }
    void checkifcorrect()
    {
        if (transform.eulerAngles == endrotation && !seconddial)
        {
            // code on finish goes here
            Debug.Log("you win");
            GreenLight.GetComponent<Image>().sprite = LitGreenLight;
            StartCoroutine(closepuzzle());
        }
        else if (seconddialGO != null && transform.eulerAngles == endrotation && seconddialGO.transform.eulerAngles == endrotation2dial)
        {
            // win again
            Debug.Log("you win x2");
            GreenLight.GetComponent<Image>().sprite = LitGreenLight;
            StartCoroutine(closepuzzle());

        }
    }
}
