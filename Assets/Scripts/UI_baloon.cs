using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;
using UnityEngine.SceneManagement;

public class UI_baloon : MonoBehaviour {

    public Image balloon;
    public Image grass;
    public Text ui_text;
    public Text ui_score;
    public Text final_score;


    private float Start_Ditsance;

    private Vector3 balloon_start; 

    public float Altitude_Ratio;

    public int Weight = 0;

    public int Score = 0;


    bool GameOver;

    public Image rawImage; 

    // Use this for initialization
    void Start () {
        Start_Ditsance = grass.rectTransform.position.y - balloon.rectTransform.position.y;

        balloon_start = balloon.rectTransform.position;

        GameOver = false;

        rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, 0);


    }



    // Update is called once per frame
    void Update () {


        if (GameOver)
        {
            rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, rawImage.color.a + 1 * Time.deltaTime);
        }
        else
        {
            balloon.rectTransform.position = new Vector3(balloon_start.x,
                                                    balloon_start.y + Start_Ditsance - Start_Ditsance * Altitude_Ratio,
                                                    balloon_start.z);

            ui_text.text = "" + Weight.ToString();

            ui_score.text = Score.ToString() + " m";

            if (Altitude_Ratio < 0.08f)
            {
                GameOver = true;

                CameraShaker.Instance.ShakeOnce(10f, 10f, 0.5f, 1.5f);

                final_score.text = "Score = " + Score.ToString() + " m";

                Invoke("Reset", 7f);
            }

        }

    }


    private void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
