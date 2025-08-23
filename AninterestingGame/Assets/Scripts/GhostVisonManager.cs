using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostVisonManager : MonoBehaviour
{
    public float visionmetermanager;
    public bool adding;
    public GameObject slider;
    public GameObject Esther;

    public GameObject MainCameraFadeBox;
    float fadeamount;
    public bool isrunning;
    public bool changed;
    // Update is called once per frame
    void Update()
    {
        if (visionmetermanager >= 20)
        {
            StartCoroutine(CameraFade());
            
            visionmetermanager = 0;
        }
    }
    public void showint(float temp)
    {
        temp = visionmetermanager;
    }

    private IEnumerator CameraFade()
    {

        isrunning = true; // runs the code only onces
        Esther.GetComponent<PlayerMovement>().canMove = false; // stop the player from moving
        while (fadeamount < 3)
        {
            fadeamount += 0.03f; // increase the transparancy of the box infrount of the camera
            MainCameraFadeBox.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, fadeamount); // give the color
            yield return null;
        }

        Esther.transform.position = new Vector2(-4.46f, -1.77f);
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
    }
}
