using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeInteraction : MonoBehaviour
{
    [Header("Spawn this object")]
    [SerializeField] private GameObject SpawnObject;
    [SerializeField] private AudioClip[] Soundeffect;
    [SerializeField] private Sprite myAchievmentImage;
    public ItemInteraction myItemInteraction;

    private bool InContact;
    public Transform KnifePoint;
    public int StabTrigger;
    private int stabAmount;
    private int Number;
    private bool achievementUnlocked;
    private bool CanDo;

    public void Start()
    {
        myItemInteraction = GetComponent<ItemInteraction>();
        Number = Random.Range(0, Soundeffect.Length);
        achievementUnlocked = false;
    }

    private void Update()
    {
        Number = Random.Range(0,Soundeffect.Length);
    }


    private void OnCollisionEnter(Collision other)
    {

            if (other.gameObject.tag == "Patient") {
                //Debug.Log("Patient stabbed"); //Delete me when obselete
                if (other.gameObject.GetComponent<CursedPatient>().CanBeStabbed == true) {
                   CreateWound();
                   stabAmount += 1;
                   


                if (stabAmount >= StabTrigger) {
                    other.gameObject.GetComponent<IChangable>().TurnPatientEmpty();
                    //other.gameObject.GetComponent<CursedPatient>().CanBeStabbed = false;
                    //Debug.Log("BAZINGA");
                    //UseAnimation.Anim_instance.DoAnim();
                    //myItemInteraction.SpawnItem();
                    if (achievementUnlocked == false) {
                           UseAnimation.Anim_instance.Achievement("You killed him", "good job", myAchievmentImage);
                           achievementUnlocked = true;
                       }
                          
                }
              }  
            }
         
    }

    void CreateWound()
    {
        //Debug.Log("Wound created"); //Delete me when obselete
        SoundManager.instance.PlaySoundEffect(Soundeffect[Number], 1f, this.transform.position); // plays random squish sound on impact
        Instantiate(SpawnObject, transform.position, Quaternion.identity);
    }

}
