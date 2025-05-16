using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neeble : MonoBehaviour
{
    bool ison1 = true;
    bool ison2 = true;
    bool ison3 = true;
    Vector3 needleTransform;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SliderValuechange(float turn)
    {
        needleTransform = transform.eulerAngles;
        transform.eulerAngles = needleTransform - new Vector3(0,0, turn);
    }
   
    IEnumerator Yabadaba (float degrees, bool isonTRUE)
    {
        Vector3 rotation = transform.eulerAngles;
        
        if (isonTRUE)
        {
            int temp = 0;
            while (temp != degrees)
            {
                temp++;
                rotation = transform.eulerAngles;
                transform.eulerAngles += Vector3.back;
                yield return new WaitForSeconds(0.02f);
                isonTRUE = false;
            }
        }
        else
        {
            int temp = 0;
            while (temp != degrees)
            {
                temp++;
                rotation = transform.eulerAngles;
                transform.eulerAngles -= Vector3.back;
                yield return new WaitForSeconds(0.02f);
                isonTRUE = true;
            }
        }
    }
    public void ButtonPressed()
    {
        StartCoroutine(Yabadaba(90, ison1));
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
        StartCoroutine(Yabadaba(90, ison2));
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
        StartCoroutine(Yabadaba(90, ison3));
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
