using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changescenes : MonoBehaviour
{
    public GameObject MainCameraFadeBox;
    public GameObject Player;
    public int SceneIndexNum;
    public bool chanewithconfermation = true;
    float fadeamount;
    public bool isrunning;
    public bool changed;
    void Update()
    {
        if (GetComponent<SpriteRenderer>().bounds.Contains(Player.transform.position) && Input.GetKeyDown("space") && chanewithconfermation)
        {
            StartCoroutine(CameraFade(SceneIndexNum)); // starts the fading on the camera
        }
        else if (GetComponent<SpriteRenderer>().bounds.Contains(Player.transform.position) && !chanewithconfermation)
        {
            StartCoroutine(CameraFade(SceneIndexNum)); // starts the fading on the camera
           
        }
    }

    private IEnumerator CameraFade(int scenenum)
    {
        isrunning = true; // runs the code only onces
        Player.GetComponent<PlayerMovement>().canMove = false; // stop the player from moving
        while (fadeamount < 3)
        {
            fadeamount += 0.03f; // increase the transparancy of the box infrount of the camera
            MainCameraFadeBox.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, fadeamount); // give the color
            yield return null;
        }

        SceneManager.LoadScene(SceneIndexNum); // loads scenes based on the index of the scenes
        changed = true;
        while (fadeamount > 0)
        {
            fadeamount -= 0.03f; // decrease the transparancy of the box infrount of the camera
            MainCameraFadeBox.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, fadeamount); // give the color
            yield return null;
        }
       
        isrunning = false; // set up so it can run again
        changed = false;
    }
}
