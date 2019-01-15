using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_Trigger : MonoBehaviour {

    public Captain_controler captain_Controler;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<Grabable_Behaviour>() != null)
        {
            if(captain_Controler.To_Grab != null)
            {
                float distance = (other.transform.position - this.transform.position).sqrMagnitude;

                float distance_current = (captain_Controler.To_Grab.transform.position - this.transform.position).sqrMagnitude; 

                if (distance < distance_current || captain_Controler.To_Grab == null)
                {
                    captain_Controler.To_Grab = other.gameObject;
                }
            }
            else
            {
                captain_Controler.To_Grab = other.gameObject;
            }
        }
    }
}
