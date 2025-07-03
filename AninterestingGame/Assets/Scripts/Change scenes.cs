using UnityEngine;
using UnityEngine.SceneManagement;

public class Changescenes : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        if (GetComponent<SpriteRenderer>().bounds.Contains(Player.transform.position) && Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(1); // loads scenes based on the index of the scenes
        }
    }
}
