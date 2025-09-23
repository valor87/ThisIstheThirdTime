using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changingrooms : MonoBehaviour
{
    public GameObject MainCameraFadeBox;
    public GameObject Esther;
    public Vector2 ChangedPos;
    Vector2 EsthersPos;
    float fadeamount;
    public bool isrunning;
    public bool changed;
    void Start()
    {
        fadeamount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        EsthersPos = Esther.transform.position;
        if (GetComponent<SpriteRenderer>().bounds.Contains(EsthersPos) && !isrunning)
        {
            StartCoroutine(CameraFade()); // starts the fading on the camera
        }
    }

    private IEnumerator CameraFade()
    {
        MainCameraFadeBox.SetActive(true);
        isrunning = true; // runs the code only onces
        Esther.GetComponent<PlayerMovement>().canMove = false; // stop the player from moving
        while (fadeamount < 3)
        {
            fadeamount += 0.03f; // increase the transparancy of the box infrount of the camera
            MainCameraFadeBox.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, fadeamount); // give the color
            yield return null;
        }

        EsthersPos = ChangedPos; // change esthers position
        Esther.transform.position = EsthersPos;
        changed = true;
        while (fadeamount > 0)
        {
            fadeamount -= 0.03f; // decrease the transparancy of the box infrount of the camera
            MainCameraFadeBox.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, fadeamount); // give the color
            yield return null;
        }
        Esther.GetComponent<PlayerMovement>().canMove = true; // give movement back
        isrunning = false; // set up so it can run again
        changed = false;
        MainCameraFadeBox.SetActive(false);
    }
}