using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] GameObject Esther;
    [SerializeField] List<GameObject> Triggercircles;
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
         Esther = collision.gameObject;
        if (Esther != Triggercircles[0] && Esther != Triggercircles[1]) {
            if (Esther.GetComponent<PlayerMovement>() != null) {
                Esther.GetComponent<PlayerMovement>().canMove = false;
                Esther.GetComponent<PlayerMovement>().speedani2 = 0;
                Esther.GetComponent<PlayerMovement>().speedani = 0;
            }
            currentpos = transform.position;

            transform.position = Vector3.Lerp(currentpos, endpos, ratio);
            Esther.transform.position = transform.position;

            if (round(Esther.transform.position) == round(endpos))
            {
                currentpos = endpos;
                endpos = startpos;
                startpos = currentpos;

                checkPlacement(startpos, endpos);
            }
        }
    }

    private void checkPlacement(Vector3 StartPos, Vector3 EndPos)
    {
        if (StartPos.y < EndPos.y)
        {
            Esther.transform.position += Vector3.down;
        }
        else if(StartPos.y > EndPos.y)
        {
            Esther.transform.position += Vector3.up;
        }

        if (round(StartPos).x > round(EndPos).x)
        {
            Esther.transform.position += Vector3.right;
        }
        else if(round(StartPos).x < round(EndPos).x)
        {
            Esther.transform.position -= Vector3.right;
        }

        if (Esther.GetComponent<PlayerMovement>() != null)
        {
            Esther.GetComponent<PlayerMovement>().canMove = true;
        }
    }
    private Vector3 round(Vector3 pos)
    {
       pos.x = Mathf.Round(pos.x);
       pos.y = Mathf.Round(pos.y);
        return pos;
    }
}
