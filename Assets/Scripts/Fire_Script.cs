using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Fire_Script : MonoBehaviour {

    private bool Combustion;

    private float Combustion_Time;

    public ParticleSystem fire;

    private Nacelle_Behaviour nacelle_Behaviour;

    AudioSource audioSource;
    public AudioClip fire_sound;



    // Use this for initialization
    void Start () {
        nacelle_Behaviour = GameObject.FindWithTag("Nacelle").GetComponent<Nacelle_Behaviour>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Combustion_Time > 0f)
        {
            Combustion_Time -= Time.deltaTime;
        }
        else
        {
            Combustion_Time = 0f;
            Combustion = false;
            fire.Stop(true);
        }

        nacelle_Behaviour.Combustion = Combustion;

        audioSource = GameObject.FindWithTag("Audio").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Burnable")
        {
            other.gameObject.SetActive(false);
            Combustion_Time += 2f;
            Combustion = true;
            fire.startColor = Color.white;
            fire.Play(true);
            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 0.1f);

            audioSource.PlayOneShot(fire_sound);
        }
        if (other.tag == "Human")
        {

            AudioClip scream =  other.gameObject.GetComponent<Human_Behviour>().scream; 

            other.gameObject.SetActive(false);
            Combustion_Time += 3f;
            Combustion = true;
            fire.startColor = Color.red;
            fire.Play(true);
            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 0.1f);

            audioSource.PlayOneShot(fire_sound);
            audioSource.PlayOneShot(scream);

        }
    }
}
