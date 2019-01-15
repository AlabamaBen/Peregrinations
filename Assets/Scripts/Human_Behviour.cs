using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Behviour : MonoBehaviour {

    bool Walking;

    Vector3 Start_position;

    Vector3 Last_position;


    public float Move_time;

    private Grabable_Behaviour grabable_Behaviour;

    public Animator animator;

    public AudioClip scream;

    float Time_walk;
    float Time_walking;

    float speed; 

    // Use this for initialization
    void Start () 
    {
        Walking = false; 

        InvokeRepeating("Target_Move", Move_time, Move_time);

        Start_position = transform.position;

        grabable_Behaviour = GetComponent<Grabable_Behaviour>();
    }
	
	// Update is called once per frame
	void Update () {

        print(Walking);
        animator.SetBool("walking", Walking);

        if (grabable_Behaviour.Is_Grab)
        {
            Walking = false;
        }

        if (Walking)
        {
            transform.Translate(0, 0, Time.deltaTime * speed);

            Time_walking += Time.deltaTime; 

            if (Time_walking > Time_walk)
            {
                Walking = false;
            }
        }
    }

    void Target_Move()
    {
        if(!Walking && !grabable_Behaviour.Is_Grab)
        {
            if (Random.Range(0f, 3f) > 1f)
            {
                float agl = Random.Range(0f, 360f);

                Time_walk = Random.Range(1f, 2f);

                speed = Random.Range(1f, 3f);

                Last_position = transform.position;

                Walking = true;

                transform.Rotate(0, agl, 0);

                Time_walking = 0;

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            transform.Rotate(0, 180f, 0);
            transform.Translate(0, 0, 0.3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            transform.Rotate(0, 180f, 0);
            transform.Translate(0, 0, 0.3f);
        }
    }

}
