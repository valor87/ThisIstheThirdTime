using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class showonscreentext : MonoBehaviour
{
    public GameObject dialaugeCanvus;
    public TextMeshProUGUI text;
    public TextAsset textasset;
    public string[] dialauge;
    public float textSpeed = 0.05f;

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown("space"))
        {
            dialaugeCanvus.SetActive(true); // turns on the canvus
            dialauge = (textasset.text.Split('\n')); // splits the entire text doc by when ever the enter button is pressed

            StartCoroutine(slowtext()); // starts the coroutine
        }
    }
    IEnumerator slowtext()
    {
        
        for (int i = 0; i < dialauge.Count(); i++)
        {
            string currenttext = dialauge[i]; // sets the line of the txt file

            for (int c = 0; c < currenttext.Length; c++)
            {
                text.text += currenttext[c]; // breaks the line into numbered letters so they can be displayed one by one
                yield return new WaitForSeconds(textSpeed); // waits based on the text speed
            }

            yield return new WaitForSeconds(1);
            text.text = string.Empty; // at the end of all the lines it sets the text box to empty
        }
        dialaugeCanvus.SetActive(false);// turns off the canvus
        yield return null;

    }
}
