using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeachScript : ItemInteraction
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Patient") {
            Debug.Log("Leach touched patient");
            collision.gameObject.GetComponent<IChangable>().TurnPatientEmpty();
        }
    }
}
