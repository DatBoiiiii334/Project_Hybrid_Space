using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maggots_Interaction : ItemInteraction
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Patient") {
            Debug.Log("Maggot touched patient");
            collision.collider.GetComponent<IChangable>().TurnPatientEmpty();
            SpawnItem();



            if (collision.gameObject.tag == "Wound") {
                Debug.Log("Maggot touched Wound");
                //SpawnItem();
                //SpawnObject.SetActive(true);
        }

            //SpawnObject.SetActive(true);
        }

        //if (collision.collider.tag == "Wound") {
            
        //    //collision.gameObject.GetComponent<IChangable>().TurnPatientEmpty();

        //    SpawnObject.SetActive(true);
        //}
    }
}
