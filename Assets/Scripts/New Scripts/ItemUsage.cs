using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUsage : ItemInteraction
{
    [Header("Item interaction tag")]
    [SerializeField] private string mytag;

    [Header("SpawnPoint")]
    //[SerializeField] private GameObject SpawnPoint;
    private Vector3 MyVec;

    [Header("Achievement Related")]
    [SerializeField] private Sprite AchievmentImage;

    [Header("Spawns Something?")]
    [SerializeField] private bool Spawns;
    private int amount;

    [Header("Options for interaction type")]
    [SerializeField] private bool TurnsPatient;
    [SerializeField] private bool Zombie;
    [SerializeField] private bool Shroom;
    [SerializeField] private bool UnHoly;
    [SerializeField] private bool Empty;
    [SerializeField] private bool Normal;
    [SerializeField] private bool Pale;


    //HEADER bools to check if achievment has been unlocked
    private bool Zombie_Achievment;
     private bool Shroom_Achievment;
     private bool UnHoly_Achievment;
     private bool Empty_Achievment;
     private bool Normal_Achievment;
    private bool Pale_Achievment;

    private void Start()
    {
        //MyVec = SpawnLocation.transform.position;
        Zombie_Achievment = true;
        Shroom_Achievment = true;
        UnHoly_Achievment = true;
        Empty_Achievment = true;
        Normal_Achievment = true;
        Pale_Achievment = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == mytag) {
            //Debug.Log("I touched " + collision.gameObject.name);

            if (Spawns == true) {
                //if(amount < SpawnAmount) {
                    SpawnItem();
                    //SpawnAmount += 1;
                //Debug.Log("Spawnerino");
                    //SpawnAmount += 1;
                    //Instantiate(SpawnObject, MyVec, Quaternion.identity);
                    //Debug.Log("Spawned correctly.. I think");
            }
            
            if (TurnsPatient) {
                if (Zombie) {
                    collision.collider.GetComponent<IChangable>().TurnPatientZombie();
                    if(Zombie_Achievment == true) {
                        UseAnimation.Anim_instance.Achievement("Dead Meat", "Turned him zombie", AchievmentImage);
                        Zombie_Achievment = false;
                    }
                }else if (Shroom) {
                    collision.collider.GetComponent<IChangable>().TurnPatientShroom();
                    if(Shroom_Achievment == true) {
                        UseAnimation.Anim_instance.Achievement("Expired", "Shroomed up", AchievmentImage);
                        Shroom_Achievment = false;
                    }
                }else if (UnHoly) {
                    collision.collider.GetComponent<IChangable>().TurnPatientUnholy();
                    if(UnHoly_Achievment == true) {
                        UseAnimation.Anim_instance.Achievement("Hell yeah", "Turned bad", AchievmentImage);
                        UnHoly_Achievment = false;
                    }
                    
                }else if (Empty) {
                    collision.gameObject.GetComponent<IChangable>().TurnPatientEmpty();
                    if(Empty_Achievment == true) {
                        UseAnimation.Anim_instance.Achievement("Turned Skelly", "Stabbed to death", AchievmentImage);
                        Empty_Achievment = false;
                    }
                    
                }else if (Normal) {
                    collision.gameObject.GetComponent<IChangable>().TurnPatientNormal();
                    if(Normal_Achievment == true) {
                        UseAnimation.Anim_instance.Achievement("Cured", "GG dude", AchievmentImage);
                        Normal_Achievment = false;
                    }
                }
                else if (Pale) {
                    collision.gameObject.GetComponent<IChangable>().TurnPatientPale();
                    if (Pale_Achievment == true) {
                        UseAnimation.Anim_instance.Achievement("Sucked", "Sucked dry", AchievmentImage);
                        Pale_Achievment = false;
                    }
                }
                else {
                    Debug.LogError("Pick only one transformation for this item");
                }
            }
            else {
                //Debug.Log("No Interaction");
                return;
            }
        }
    }


}
