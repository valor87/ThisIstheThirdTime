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

    MonoBehaviour screentect;
    private void Start()
    {
        screentect = GetComponent<showonscreentext>();
    }
    void Update()
    {

        if (GetComponent<SpriteRenderer>().bounds.Contains(Esther.transform.position) && Input.GetKeyDown("space"))
        {
            if (showObject.GetComponent<showonscreentext>() != null) {
                if (!showObject.GetComponent<showonscreentext>().overlayon)
                {
                    showObject.SetActive(true);
                    showObject.GetComponent<showonscreentext>().textasset = text;
                    if (text != null)
                    {

                        textMp.color = textcolor;
                        showObject.GetComponent<showonscreentext>().textasset = text;
                        showObject.GetComponent<showonscreentext>().playerchoice = choice;
                        if (doorUnlock != null)
                        {
                            doorUnlock.GetComponent<Doorlockedscript>().doorlocked = false;
                        }
                        showObject.GetComponent<showonscreentext>().textasset = text;
                        showObject.GetComponent<showonscreentext>().playerchoice = choice;
                    }
                }
            }
            else
            {
                showObject.SetActive(true);
            }
        }
    }
}
