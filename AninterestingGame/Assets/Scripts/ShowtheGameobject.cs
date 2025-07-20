using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowtheGameobject : MonoBehaviour
{
    public GameObject doorUnlock;
    public TextMeshProUGUI textMp;
    public GameObject Esther;
    public GameObject showObject;
    public TextAsset text;
    public bool choice;
    public Color textcolor;
    
  
    void Update()
    {
        
        if (GetComponent<SpriteRenderer>().bounds.Contains(Esther.transform.position) && Input.GetKeyDown("space") && !showObject.GetComponent<showonscreentext>().overlayon)
        {
            textMp.color = textcolor;
            if (text != null)
            {
                
                showObject.GetComponent<showonscreentext>().textasset = text;
                showObject.GetComponent<showonscreentext>().playerchoice = choice;
                if (doorUnlock != null)
                {
                    doorUnlock.GetComponent<Doorlockedscript>().doorlocked = false;
                }
            }
            showObject.SetActive(true); // show the object

        }
    }
}
