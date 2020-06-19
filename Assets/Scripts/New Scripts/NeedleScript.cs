using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleScript : MonoBehaviour
{
    public Renderer CurrentMaterial;

    public Material GreenMat;
    public Material RedMat;
    public Material BlueMat;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Zombie_Vile") {
            CurrentMaterial.material = GreenMat;
            Debug.Log("Green");
        }
        if (collision.collider.name == "Blood_Vial(Clone)") {
            CurrentMaterial.material = RedMat;
            Debug.Log("Red");
        }
    }
}
