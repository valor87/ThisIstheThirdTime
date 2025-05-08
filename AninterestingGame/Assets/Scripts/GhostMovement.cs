using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float t = 0;
    public Vector2 start;
    public Vector2 end;
    Vector2 ghostpos;
    public AnimationCurve curve;
    public List<Transform> listofplacestogo;

    private void Start()
    {
      
        ghostpos = start;
        transform.position = ghostpos;
    }
    // Update is called once per frame
    void Update()
    {
        if (t > 1)
        {
            
        }
        ghostpos = transform.position;
        if (start != null && end != null)
        {
            if (ghostpos.x > end.x)
            {
                ghostpos.x -= 0.001f;
                transform.localScale = new Vector2(1, 0.81438f);
            }
            if (ghostpos.x < end.x)
            {
                ghostpos.x += 0.001f;
                transform.localScale = new Vector2(-1, 0.81438f);
            }
            if (ghostpos.y > end.y)
            {
                ghostpos.y -= 0.001f;
            }
            if (ghostpos.y < end.y)
            {
                ghostpos.y += 0.001f;
            }

            transform.position = ghostpos;
        }
    }
    
}
