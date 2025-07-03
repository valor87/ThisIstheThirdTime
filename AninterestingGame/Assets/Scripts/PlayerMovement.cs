
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public bool canMove = true;
    Rigidbody2D Rb;

    public Animator PA;
    public float speedani;
    public float speedani2;

    public float Vinput;
    public float Hinput;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
         
    }
    private void FixedUpdate()
    {
        if (canMove)
        {

            Hinput = Input.GetAxis("Horizontal") * speed;
            Vinput = Input.GetAxis("Vertical") * speed;
            Rb.velocity = new Vector2(Hinput, Vinput);
            changeanimation();

        }
        
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("left shift"))
        {
            speed = 7;
            PA.speed = 2;
        }
        else
        {
            PA.speed = 1;
            speed = 5;
        }

    }
    private void changeanimation()
    {
       
        if (Input.GetKey("d"))
        {
            GetComponent<SpriteRenderer>().flipX = true;
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
            GetComponent<SpriteRenderer>().flipX = false;
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
        
        PA.SetFloat("Directionx", speedani);
        PA.SetFloat("Directiony", speedani2);
    }

}


