using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nacelle_Object : MonoBehaviour {

    public int Weigth; 

    private Nacelle_Behaviour nacelle_Behaviour; 

	// Use this for initialization
	void Start () {
        nacelle_Behaviour = GameObject.FindWithTag("Nacelle").GetComponent<Nacelle_Behaviour>();

        nacelle_Behaviour.nacelle_Objects.Add(this); 
    }



}
