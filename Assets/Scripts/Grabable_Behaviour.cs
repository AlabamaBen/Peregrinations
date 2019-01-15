using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable_Behaviour : MonoBehaviour {

    

    private GameObject anchor;

    public bool Is_Grab;

    public float smoothTime = 0.1F;
    private Vector3 velocity = Vector3.zero;

    public bool Human;

    private Vector3 Start_Position;
    private Quaternion Start_Rotation;

    // Use this for initialization
    void Start()
    {
        Is_Grab = false;
        Start_Position = transform.localPosition;
        Start_Rotation = transform.rotation;
        Stand = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Is_Grab)
        {
            Vector3 targetPosition = anchor.transform.TransformPoint(new Vector3(0, 0, 0));

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }

    public void Be_Grab(GameObject _anchor)
    {
        anchor = _anchor;
        Is_Grab = true;
        transform.Rotate(90, 0, 0);
        Stand = false;
        GetComponent<Rigidbody>().useGravity = false;
    }

    public void Stop_Be_Grab(Vector3 direction,  float Throw_force)
    {
        anchor = null;
        Is_Grab = false;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().AddForce(direction * Throw_force, ForceMode.Impulse);
        GetComponent<Rigidbody>().useGravity = true;
    }

    public bool Stand;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            if(!Is_Grab && !Stand && Human)
            {
                Invoke("StadeUp", 2f);
            }
        }
        if (collision.gameObject.tag == "Death")
        {
            this.gameObject.SetActive(false);
            //Object.Destroy(this.gameObject);
        }
    }

    private void StadeUp()
    {
        if(!Is_Grab)
        {
            GetComponent<Rigidbody>().useGravity = false;
            transform.localPosition = new Vector3(transform.position.x, Start_Position.y, transform.position.z);
            transform.rotation = Start_Rotation;
            Stand = true;

        }
    }

}
