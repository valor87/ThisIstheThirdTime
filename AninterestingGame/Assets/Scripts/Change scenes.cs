using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changescenes : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        if (GetComponent<SpriteRenderer>().bounds.Contains(Player.transform.position) && Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(2); // loads scenes based on the index of the scenes
        }
    }
}
