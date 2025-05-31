using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class GameObjectCarCode : MonoBehaviour
{
    float temptime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(1) && GetComponent<SpriteRenderer>().bounds.Contains(mousepos))
        {
            GetComponent<SplineAnimate>().ElapsedTime += 0.8f;
        }
        else
        {
            GetComponent<SplineAnimate>().enabled = true;
            GetComponent<SplineAnimate>().Play();
        }

        if (new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y)) == new Vector2(1, -2))
        {
            GetComponent<SplineAnimate>().Pause();
        }
    }
}
