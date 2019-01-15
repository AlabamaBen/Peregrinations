using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Captain_controler : MonoBehaviour {

    public float speed = 3.0F;
    public float rotateSpeed = 200.0F;

    public float Throw_force = 2.0F;
    

    public GameObject To_Grab;

    private GameObject Is_Grab;

    public GameObject Anchor; 

    private bool Grabing;

    private float throw_culldown;

    public Animator animator;

    Rigidbody rb;


    AudioSource audioSource; 
    public AudioClip throw_sound;

    public AudioClip step_sound;
    public AudioClip pick_sound; 

    bool walking; 

    private void Start()
    {
        walking = false;

        Grabing = false;
        throw_culldown = 0f;
        To_Grab = null;
        Is_Grab = null;

        rb = GetComponent<Rigidbody>();

        audioSource = GameObject.FindWithTag("Audio").GetComponent<AudioSource>();

        GetComponent<AudioSource>().volume = 0f; 
    }

    void Update()
    {

        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);


        Vector3 dir_in = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));

        if(dir_in.magnitude > 0f)
        {
            transform.forward = dir_in;

            transform.Translate(0, 0, Time.deltaTime * speed);

            GetComponent<AudioSource>().volume = dir_in.magnitude;

            animator.SetBool("walking", true);

        }
        else
        {
            animator.SetBool("walking", false);
        }


        if (throw_culldown > 0.1f)
        {
            throw_culldown = throw_culldown - Time.deltaTime;
        }
        else
        {
            //particleSystem.Stop(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Grabing)
                {
                    Throw_grab();
                }
                else if (To_Grab != null)
                {
                    Is_Grab = To_Grab;
                    Is_Grab.GetComponent<Grabable_Behaviour>().Be_Grab(Anchor);
                    Grabing = true;
                    animator.SetTrigger("pick");
                    audioSource.PlayOneShot(pick_sound);
                }

                print("To Grabe : " + To_Grab);
                print("Is Grabe : " + Is_Grab);
            }
        }
    }


    private void Throw_grab()
    {
        print("TRHOW : ");
        throw_culldown = 1f;
        Is_Grab.GetComponent<Grabable_Behaviour>().Stop_Be_Grab(this.transform.forward + this.transform.up, Throw_force);
        Grabing = false;
        Is_Grab = null;

        audioSource.PlayOneShot(throw_sound);

        animator.SetTrigger("throw");
        //particleSystem.Play(true);
    }

}
