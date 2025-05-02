using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowtheGameobject : MonoBehaviour
{
    public GameObject Esther;
    public GameObject showObject;
    void Update()
    {
        if (GetComponent<SpriteRenderer>().bounds.Contains(Esther.transform.position) && Input.GetKeyDown("space"))
        {
            showObject.SetActive(true); // show the object
        }
    }
}
