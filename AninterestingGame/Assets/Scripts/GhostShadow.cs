using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GhostShadow : MonoBehaviour
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
        Vector2 scale = transform.localScale;
        while (t < 1)
        {
            scale = new Vector3(1, .5f, 1)  * curve.Evaluate(t);
            t += .3f * Time.deltaTime;
            transform.localScale = scale;
            yield return null;
        }
        
    }
}
