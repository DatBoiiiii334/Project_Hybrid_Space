
using UnityEngine;

public class GroteBozeResetKnop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.currentPatient.ResetPatient();
    }
}
