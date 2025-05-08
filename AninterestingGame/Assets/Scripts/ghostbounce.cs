using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ghostbounce : MonoBehaviour
{
    public AnimationCurve curve;
    public float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(floatingbounce());
    }

    // Update is called once per frame
    void Update()
    {
        if (t > 1)
        {
            StopAllCoroutines();
            StartCoroutine(floatingbounce());
        }
    }

    IEnumerator floatingbounce()
    {
        t = 0;
        Vector2 pos = transform.position;
        while (t < 1)
        { 
            pos = transform.position;
            pos.y +=  .5f * curve.Evaluate(t);
            //t += .3f * Time.deltaTime;
            transform.position = pos;
            pos.y -= .5f * curve.Evaluate(t);
            
            yield return new WaitForSeconds(.025f);
        }

    }
}
