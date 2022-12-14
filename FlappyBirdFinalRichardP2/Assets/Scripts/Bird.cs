using System.Collections;
using UnityEngine;

public class Bird : MonoBehaviour { 

    public float upForce = 200f;
    AudioSource audioSource;
    public AudioClip Flap;
    public AudioClip Death;
    public AudioClip Score;
    public bool alreadyPlayed = false;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    //Update is called once per frame
    void Update ()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown (0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
                audioSource.PlayOneShot(Flap);
            }
        }
    }

    void OnCollisionEnter2D ()
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameController.instance.BirdDied();
        if (alreadyPlayed == false)
        {
            audioSource.PlayOneShot(Death);
            alreadyPlayed= true;
        }
    }
    void OnTriggerEnter2D ()
    {
        if (isDead == false)
        {
            audioSource.PlayOneShot(Score);
        }
    }
}