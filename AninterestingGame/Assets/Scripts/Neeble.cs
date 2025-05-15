using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neeble : MonoBehaviour
{
    Vector3 needleTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed ()
    {
        NeedleDoTricksOnIt(-90);
    }

    void NeedleDoTricksOnIt (float zrotation)
    {
        needleTransform = new Vector3(0, 0, zrotation);
        StartCoroutine(Yabadaba(needleTransform));
    }

    IEnumerator Yabadaba (Vector3 _temp)
    {
        Vector3 rotation = transform.eulerAngles;
        Vector3 newRotation = _temp;
        while (transform.eulerAngles != newRotation)
        {
            transform.eulerAngles += Vector3.back;
            yield return new WaitForSeconds(0.25f);
        }
    }
}
