using UnityEngine;
using UnityEngine.SceneManagement;

public class Changescenes : MonoBehaviour
{
    public GameObject Player;
    public int SceneIndexNum;
    void Update()
    {
        if (GetComponent<SpriteRenderer>().bounds.Contains(Player.transform.position) && Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(SceneIndexNum); // loads scenes based on the index of the scenes
        }
    }
}
