using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] GameObject Esther;
    [SerializeField] Vector3 startpos;
    [SerializeField] Vector3 endpos;
    Vector3 currentpos;
    [SerializeField] float ratio;
    private void Start()
    {
        startpos = transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject Esther = collision.gameObject;
        if (Esther.GetComponent<PlayerMovement>() != null) {
            Esther.GetComponent<PlayerMovement>().canMove = false;
            Esther.GetComponent<PlayerMovement>().speedani2 = 0;
            Esther.GetComponent<PlayerMovement>().speedani = 0;
        }
        currentpos = transform.position;
        Debug.Log("running");
       
        transform.position = Vector3.Lerp(currentpos, endpos, ratio);
        Esther.transform.position = transform.position;

        if (round(Esther.transform.position) == round(endpos))
        {
            currentpos = endpos;
            endpos = startpos;
            startpos = currentpos;
            Debug.Log("Platform done");
            if (startpos.x <= endpos.x)
            {
                Esther.transform.position -= new Vector3(1, 0);
                if (Esther.GetComponent<PlayerMovement>() != null)
                {
                    Esther.GetComponent<PlayerMovement>().canMove = true;
                }
            }
            else
            {
                Esther.transform.position += new Vector3(1, 0);
                if (Esther.GetComponent<PlayerMovement>() != null)
                {
                    Esther.GetComponent<PlayerMovement>().canMove = true;
                }
            }
        }
    }

    private Vector3 round(Vector3 pos)
    {
       pos.x = Mathf.Round(pos.x);
       pos.y = Mathf.Round(pos.y);
        return pos;
    }
}
