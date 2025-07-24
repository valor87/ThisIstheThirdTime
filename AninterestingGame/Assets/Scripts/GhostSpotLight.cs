using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostSpotLight : MonoBehaviour
{
    public GameObject slider;
    public float visionmeter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log("collision");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("staying collision");
        visionmeter += 0.1f;
        slider.GetComponent<Slider>().value = visionmeter;
    }

    public void showint(float temp)
    {
        temp = visionmeter;
    }
}
