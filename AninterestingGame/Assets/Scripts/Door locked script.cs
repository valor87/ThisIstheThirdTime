using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Doorlockedscript : MonoBehaviour
{
    public bool doorlocked = true;
    public GameObject showObject;
    public TextAsset text;
    public GameObject Esther;
    void Update()
    {
        if (GetComponent<SpriteRenderer>().bounds.Contains(Esther.transform.position) && Input.GetKeyDown("space") && doorlocked)
        {
            if (text != null)
            {
                showObject.GetComponent<showonscreentext>().textasset = text;
                showObject.GetComponent<showonscreentext>().playerchoice = false;
            }
            showObject.SetActive(true); // show the object
        }
        else if (GetComponent<SpriteRenderer>().bounds.Contains(Esther.transform.position) && Input.GetKeyDown("space") && !doorlocked)
        {
            SceneManager.LoadScene(1);
        }
    }
}
