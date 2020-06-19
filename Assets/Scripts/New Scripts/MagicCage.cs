using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCage : MonoBehaviour
{
    public GameObject Self;
    public GameObject Other;

    public void Start()
    {
        //Other.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "SkeletonKey(Clone)") {
            GetGot();
            Debug.Log(">Got Got");
        }
    }

    public void GetGot()
    {
        Self.SetActive(false);
        Other.SetActive(true);
    }
}
