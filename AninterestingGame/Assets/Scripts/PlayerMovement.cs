
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public bool canMove = true;
    Rigidbody2D Rb;
    SpriteRenderer sr;
    public Animator PA;
    public float speedani;
    public float speedani2;

    public float Vinput;
    public float Hinput;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            Hinput = Input.GetAxisRaw("Horizontal") * speed;
            Vinput = Input.GetAxisRaw("Vertical") * speed ;
            Rb.velocity = new Vector2(Hinput, Vinput);
            changeanimation();
        }
        
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("left shift"))
        {
            speed = 6;
            PA.speed = 2;
        }
        else
        {
            PA.speed = 1;
            speed = 4;
        }
        PA.SetFloat("Directionx", speedani);
        PA.SetFloat("Directiony", speedani2);
    }
    private void changeanimation()
    {
       
        if (Input.GetKey("d"))
        {
            sr.flipX = true;
            speedani = -1;
            speedani2 = 0;
        }
        else if (Input.GetKey("w"))
        {
            speedani2 = 1;
            speedani = 0;
        }
        else if (Input.GetKey("a"))
        {
            speedani = -1;
            speedani2 = 0;
            sr.flipX = false;
        }
    
        else if (Input.GetKey("s"))
        {
            speedani2 = -1;
            speedani = 0;
        }
        else
        {
            speedani = 0;
            speedani2 = 0;
        }
    }

}


