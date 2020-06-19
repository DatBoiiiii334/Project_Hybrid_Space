using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject SpawnCube;
    public GameObject PoofEffect;


    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Interactable") {
            if(other.collider.GetComponent<IChangePos>() != null) {
                other.collider.GetComponent<IChangePos>().ChangePosition(SpawnCube.transform.position.x, SpawnCube.transform.position.y, SpawnCube.transform.position.z, Quaternion.identity);
                //Debug.Log("Changed Pos of " + other.gameObject.name);
            }
            else {
                //Debug.Log("No IChangePos detected");
                return;
            }
            //SpawnHere = Vector3(Collision.transform.position);
            Instantiate(PoofEffect, other.collider.transform.position, other.transform.rotation);
        }
        else {
            return;
        }

       
        
        
    }

}
