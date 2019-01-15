using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_Spawner : MonoBehaviour {

    public List<GameObject> Cloud_Prefabs;

    float time;

    public float Frequency = 6f;

	// Use this for initialization
	void Start () 
    {
        time = Frequency; 
    }
	
	// Update is called once per frame
	void Update () 
    {
		if(time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Spawn_Cloud();
        }
    }

    void Spawn_Cloud()
    {
        if (Random.Range(0f, 2f) > 1f)
        {
            int i = Random.Range(0, Cloud_Prefabs.Count - 1);

            GameObject cloud = Cloud_Prefabs[i];

            GameObject new_cloud = Instantiate(cloud, this.transform, true);

            new_cloud.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            new_cloud.AddComponent<Cloud_Behaviour>();


        }
        time = Frequency; 
    }
}
