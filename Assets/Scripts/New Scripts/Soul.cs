using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : ItemInteraction
{ 

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Soul touched Zombie");
        if(collision.collider.tag == "Zombie") {
            collision.gameObject.GetComponent<IChangable>().TurnPatientUnholy();
        }
    }
}
