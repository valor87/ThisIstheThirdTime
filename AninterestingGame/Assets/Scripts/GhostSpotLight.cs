using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostSpotLight : MonoBehaviour
{
    public GameObject slider;
    public float visionmeter;
    public bool adding;
    private void Update()
    {
        if (visionmeter > 0 && !adding)
        {

            visionmeter -= 5 * Time.deltaTime;

        }
        slider.GetComponent<Slider>().value = visionmeter;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        adding = true;
        Debug.Log("staying collision");
        if (visionmeter < slider.GetComponent<Slider>().maxValue)
        {
            visionmeter += 5 * Time.deltaTime;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        adding = false;
    }
    public void showint(float temp)
    {
        temp = visionmeter;
    }
}
