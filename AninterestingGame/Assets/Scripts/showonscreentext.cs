using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using TMPro;
using UnityEngine;

public class showonscreentext : MonoBehaviour
{
    public GameObject Esther;
    public GameObject triggerArea;
    GameObject Image;
    GameObject conIcon;
    GameObject Textobject;
    TextMeshProUGUI text;
    SpriteRenderer sp;
    public TextAsset textasset;
    public string[] dialauge;
    public float textSpeed = 0.05f;
    bool continueText;
    bool texton;

    private void Start()
    {
        sp = triggerArea.GetComponent<SpriteRenderer>();
        Transform imagetr = transform.GetChild(0);
        Image = imagetr.gameObject;
        Transform texttr = transform.GetChild(1);
        Textobject = texttr.gameObject;
        text = Textobject.GetComponent<TextMeshProUGUI>();
        Transform contr = transform.GetChild(2);
        conIcon = contr.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && texton == false && sp.bounds.Contains(Esther.transform.position))
        {
            dialauge = (textasset.text.Split('\n')); // splits the entire text doc by when ever the enter button is pressed
            StartCoroutine(slowtext()); // starts the coroutine
        }
    }
    IEnumerator slowtext()
    {
        
        texton = true;
        turnOnUi(); // turns on the canvus
        for (int i =0; i < dialauge.Count(); i++)
        {
            string currenttext = dialauge[i]; // sets the line of the txt file

            for (int c = 0; c < currenttext.Length; c++)
            {
                text.text += currenttext[c]; // breaks the line into numbered letters so they can be displayed one by one
                Debug.Log("Working");
                yield return new WaitForSeconds(textSpeed); // waits based on the text speed
            }

            yield return new WaitForSeconds(1);

            continueText = true;

            while (continueText)
            {

                if (Input.GetKey("w"))
                {
                    continueText = false;
                    text.text = string.Empty; // at the end of all the lines it sets the text box to empty
                }
                yield return null;
            }
            text.text = string.Empty; // at the end of all the lines it sets the text box to empty
        }
        turnOffUi();// turns off the canvus
        texton = false;
        yield return null;

    }

    private void turnOnUi()
    {
        Esther.GetComponent<PlayerMovement>().canMove = false;
        Image.SetActive(true);
        Textobject.SetActive(true);
        conIcon.SetActive(true);
    }
    private void turnOffUi()
    {
        Esther.GetComponent<PlayerMovement>().canMove = true;
        Image.SetActive(false);
        Textobject.SetActive(false);
        conIcon.SetActive(false);
    }
}
