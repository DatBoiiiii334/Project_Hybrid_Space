using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public GameObject SpawnPosition;
    public AudioClip FoodMunchies;

    private bool Spawn = true;


    private void OnCollisionEnter(Collision collision)
    {
        if(Spawn == true) {
            if (collision.collider.tag == "Mouth") {
                Spawn = false;
                SoundManager.instance.PlaySoundEffect(FoodMunchies, 1f, this.transform.position);
                StartCoroutine(UseAnimation.Anim_instance.BlinkBread());
            }
        }
        
    }
}
