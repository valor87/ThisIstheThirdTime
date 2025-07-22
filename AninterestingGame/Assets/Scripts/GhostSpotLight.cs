using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpotLight : MonoBehaviour
{
    public GameObject Player;
    public GameObject SpotGuage;
    SpriteRenderer sp;
    Vector2 guagepos;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        guagepos = Camera.main.ScreenToWorldPoint(SpotGuage.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(guagepos);
        SpotGuage.transform.position = Player.transform.position;
        if (sp.bounds.Contains(Player.transform.position))
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }

    }

}
