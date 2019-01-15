using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_Behaviour : MonoBehaviour {


    private float speed;

	// Use this for initialization
	void Start () {

        speed = Random.Range(1f, 3f);

        float scale = Random.Range(0.4f, 0.8f);
        transform.localScale = new Vector3(scale, scale, scale);

        this.transform.position = new Vector3(transform.position.x + Random.Range(-20, 20), transform.position.y + Random.Range(-2, 0), transform.position.z);

        Object.Destroy(this.gameObject, 40);
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * speed); 
	}
}
