using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHightStairs : MonoBehaviour
{
    [SerializeField] GameObject Esther;
    [SerializeField] float changeamount;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("staying");
        Vector2 estherspos = Esther.transform.position;
        if (Input.GetKey("d"))
        {
            estherspos.y += changeamount * Time.deltaTime;
        }
        else if (Input.GetKey("a"))
        {
            estherspos.y -= changeamount * Time.deltaTime;
        }

        Esther.transform.position = estherspos;
    }
}
