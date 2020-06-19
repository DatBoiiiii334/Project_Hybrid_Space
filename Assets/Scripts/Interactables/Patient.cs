using UnityEngine;
using System.Collections.Generic;

public class Patient : MonoBehaviour, IInteractable {

	[Header ("Body GameObjects")]
	[SerializeField] private GameObject NormalBody;
	[SerializeField] private GameObject SkeletalBody;
	[SerializeField] private GameObject ZombieBody;

	[Header ("Wound Prefabs")]
	[SerializeField] private GameObject smallWoundPrefab;
	[SerializeField] private GameObject bigWoundPrefab;
	[SerializeField] private GameObject cleanWound;
	private List<GameObject> woundList = new List<GameObject> ();

	[Header ("Misc Object References")]
	[SerializeField] private ParticleSystem smokePoofParticle;
	[SerializeField] private SpecialMushroom specialMushroom;
	[SerializeField] private GameObject skeletonKey;
	[SerializeField] private GameObject MaggotsUnlock;
	[SerializeField] private GameObject AshPileUnlock;

	private PatientState state = PatientState.alive;


	public void OnInteract () {

	}

	public void CauseWound (Vector3 woundLocation) {
		if (state != PatientState.alive)
			return;

		if (woundList.Count != 0) {
			foreach (GameObject wound in woundList) {
				if (Vector3.Distance (wound.transform.position, woundLocation) <= .8f) {
					if (wound.GetComponent<Wound> ().woundType != Wound.WoundType.Big) {    // Turn wound into bloodier wound if not already
						GameObject bigWound = Instantiate (bigWoundPrefab, wound.transform.position, Quaternion.identity, this.transform);
						woundList.Add (bigWound);

						woundList.Remove (wound);
						Destroy (wound);
					}
					return; // If Wound in range is found, return without placing a new one
				}
			}
		}

		GameObject newWound = Instantiate (smallWoundPrefab, woundLocation, Quaternion.identity, this.transform);
		woundList.Add (newWound);

		if (woundList.Count > 4) {  // Too many wounds, patient dies
			Die ();
		}
	}

	public void MaggotWound (Wound wound) {
		if (state != PatientState.alive)
			return;

		foreach (GameObject w in woundList) {
			if (wound.Equals (w)) {
				GameObject newWound = Instantiate (cleanWound, wound.transform.position, Quaternion.identity, this.transform);
				woundList.Add (newWound);

				woundList.Remove (w);
				Destroy (w);
			}
		}
	}

	public void EatenByMaggots () {
		if (state != PatientState.dead)
			return;

		smokePoofParticle.Play ();

		state = PatientState.skeleton;
		NormalBody.SetActive (false);
		SkeletalBody.SetActive (true);

		skeletonKey.SetActive (true);
	}

	public void MushroomGrowth () {
		if (state != PatientState.alive)
			return;

		state = PatientState.dead;

		if (!specialMushroom.gameObject.active)
			specialMushroom.gameObject.SetActive (true);
	}

	public void TurnZombie () {
		if (state != PatientState.alive)
			return;

		smokePoofParticle.Play ();

		state = PatientState.zombie;
		NormalBody.SetActive (false);
		ZombieBody.SetActive (true);

		if (!MaggotsUnlock.gameObject.active)
			MaggotsUnlock.SetActive (true);
	}

	public void BurnZombie () {
		if (state != PatientState.zombie)
			return;

		smokePoofParticle.Play ();

		state = PatientState.burned;
		ZombieBody.SetActive (false);
		if (!AshPileUnlock.gameObject.active)
			AshPileUnlock.SetActive (true);
	}

	private void Die () {
		state = PatientState.dead;
        Debug.Log("Is dead");
	}

    public void ResetPatient ()
    {
        smokePoofParticle.Play();

        state = PatientState.alive;
        NormalBody.SetActive(true);
        ZombieBody.SetActive(false);
        SkeletalBody.SetActive(false);

        foreach (GameObject w in woundList)
        {
            woundList.Remove(w);
            Destroy(w.gameObject);
        }
    }


    private enum PatientState {
		alive, 
		dead,
		skeleton,
		zombie,
		burned,
	};

}
