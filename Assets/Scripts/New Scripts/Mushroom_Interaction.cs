using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Interaction : MonoBehaviour
{
    public GameObject Desired_Item_Change;
    public Material NewMat;

    [Header("Achievement Related")]
    [SerializeField] private Sprite AchievmentImage;

    private bool TurnPatientNormal = false;
    private bool Normal_Achievment = true;
    //public Material MyMat;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Mushroom") {
            Desired_Item_Change.GetComponent<Renderer>().material = NewMat;
            TurnPatientNormal = true;
            Debug.Log("MUSHROOM DETECTED");
        }

        if (collision.collider.tag == "Patient") {
            if (TurnPatientNormal == true) {
                Debug.Log("Can be cured");
                collision.gameObject.GetComponent<IChangable>().TurnPatientNormal();
                if (Normal_Achievment == true) {
                    UseAnimation.Anim_instance.Achievement("Cured", "GG dude", AchievmentImage);
                    Normal_Achievment = false;
                }
            }
        }
    }
}
