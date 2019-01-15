using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nacelle_Behaviour : MonoBehaviour {

    public List<Nacelle_Object> nacelle_Objects;

    public float speed ;

    private float Start_Altitude;

    public UI_baloon uI_Baloon;

    public bool Combustion;

    private float time; 


    // Use this for initialization
    void Start () {

        Start_Altitude = transform.position.y;

        Combustion = false;

        time = 0f; 

    }
	
	// Update is called once per frame
	void Update () {

        int weight = Get_TotalWeight();

        float speed_w = Time.deltaTime * speed * (weight + 5 ) / 20;

        if(Combustion)
        {
            speed_w -= 5f * Time.deltaTime; 
        }

        time += Time.deltaTime; 

        transform.Translate(new Vector3(0, -speed_w, 0));

        uI_Baloon.Altitude_Ratio = transform.position.y / Start_Altitude;

        uI_Baloon.Weight = weight;

        uI_Baloon.Score = (int)time; 


        //print("Altitude : " + transform.position.y / Start_Altitude);
    }

    int Get_TotalWeight()
    {
        int total = 0;

        foreach(Nacelle_Object obj in nacelle_Objects)
        {
            if(obj.gameObject.activeInHierarchy)
            {
                total += obj.Weigth;
            }
        }
        return total; 
    }


}
