using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnOnFirstFairytale : MonoBehaviour
{

    public GameObject blackBox;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        GetComponent<showonscreentext>().enabled = true;
        while (GetComponent<showonscreentext>().texton == true)
        {
            if (!GetComponent<showonscreentext>().texton)
            {
                blackBox.GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<showonscreentext>().enabled = false;
            }
            yield return null;
        }
        
    }
}
