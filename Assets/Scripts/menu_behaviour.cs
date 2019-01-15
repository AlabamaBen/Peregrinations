using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu_behaviour : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            print("Enter");
            SceneManager.LoadScene(1);
        }
    }
}
