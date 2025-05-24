using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float t = 0;
    public Vector2 start;
    public Vector2 end;
    Vector2 destination;
    Vector2 ghostpos;
    public AnimationCurve curve;
    public List<Transform> listofplacestogo;

    private void Start()
    {
        destination = end;
          ghostpos = start;
        transform.position = ghostpos;
    }
    // Update is called once per frame
    void Update()
    {
        ghostpos.x = Mathf.Round(ghostpos.x);
        ghostpos.y = Mathf.Round(ghostpos.y);
        if (ghostpos == end)
        {
            destination = start;
        }
        if (ghostpos == start)
        {
            destination = end;
        }
        if (t > 1)
        {
            
        }
        ghostpos = transform.position;
        if (start != null && end != null)
        {
            if (ghostpos.x > destination.x)
            {
                ghostpos.x -= 0.001f;
                transform.localScale = new Vector2(1, 0.81438f);
            }
            if (ghostpos.x < destination.x)
            {
                ghostpos.x += 0.001f;
                transform.localScale = new Vector2(-1, 0.81438f);
            }
            if (ghostpos.y > destination.y)
            {
                ghostpos.y -= 0.001f;
            }
            if (ghostpos.y < destination.y)
            {
                ghostpos.y += 0.001f;
            }
            
                transform.position = ghostpos;
        }
    }
    
}
