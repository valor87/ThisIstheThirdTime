using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowtheGameobject : MonoBehaviour
{
    public GameObject Esther;
    public GameObject showObject;
    public TextAsset text;
    void Update()
    {
        if (GetComponent<SpriteRenderer>().bounds.Contains(Esther.transform.position) && Input.GetKeyDown("space") && !showObject.GetComponent<showonscreentext>().overlayon)
        {
            if (text != null)
            {
                showObject.GetComponent<showonscreentext>().textasset = text;

            }
            showObject.SetActive(true); // show the object

        }
    }
}
