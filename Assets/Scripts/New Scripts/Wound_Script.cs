using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wound_Script : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wound") {
            Debug.Log("Killed wound");
            Destroy(collision.gameObject);
        }
    }
}
