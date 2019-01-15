using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgound_behaviour : MonoBehaviour {


    public float Background_Speed = 0.1f;



    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {

        float delta = Time.deltaTime * Background_Speed;
        // Animates main texture scale in a funky way!

        float scalex = (Mathf.Sin(Time.time)) * Time.deltaTime * Background_Speed;

        rend.material.mainTextureOffset = new Vector2(rend.material.mainTextureOffset.x + scalex, rend.material.mainTextureOffset.y + delta);
    }
}
