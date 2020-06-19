using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour, IChangePos
{
    [Header("Spawn this object")]
    [SerializeField] protected List<GameObject> SpawnObject;
    [SerializeField] protected AudioClip Soundeffect;
    [SerializeField] protected GameObject SpawnLocation;
    [SerializeField] protected int SpawnAmount;


    public void ChangePosition(float PosX, float PosY, float PosZ, Quaternion rotation)
    {
        transform.position = new Vector3(PosX, PosY, PosZ);
        transform.rotation = rotation;
        Debug.Log("Done transforming" + this.gameObject.name);
    }

    public void SpawnItem()
    {
        if(SpawnAmount <= 1) {
            SpawnAmount += 1;
            for (int i = 0; i < SpawnObject.Count; i++) {
                Instantiate(SpawnObject[i], SpawnLocation.transform.position, Quaternion.identity);
                Debug.Log("Spawns shit");
            }
        }
        else {
            return;
        }
    }

}
