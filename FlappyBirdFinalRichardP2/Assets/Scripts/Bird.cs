using System.Collections;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float upForce = 200f;            //Upward force of the "flap".
    
    private bool isDead = false;            //Has the player collided with a wall?
    private Animator anim;                    //Reference to the Animator component.
    private Rigidbody2D rb2d;                //Holds a reference to the Rigidbody2D component of the bird.


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Don't allow control if the bird has died.
        if (isDead == false)
        {
            //...tell the animator about it and then...
            if (Input.GetMouseButtonDown (0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isDead = true;
        anim.SetTrigger("Die");
    }
}
