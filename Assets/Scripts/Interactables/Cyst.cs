using UnityEngine;
using System.Collections;

public class Cyst : MonoBehaviour, IInteractable {

	[SerializeField] private GameObject particleObject;

	[SerializeField] private AudioClip squishSound;

	[HideInInspector] public bool isLeaking = false;

	public void OnInteract () {
		if (!isLeaking) {
			particleObject.SetActive (true);
			isLeaking = true;
			SoundManager.instance.PlaySoundEffect (squishSound, 1, this.transform.position);

			StartCoroutine (DisableInTime ());
		}
	}

	IEnumerator DisableInTime () {
		yield return new WaitForSeconds (2);

		isLeaking = false;
		particleObject.SetActive (false);
		gameObject.GetComponentInParent<Patient> ().CauseWound (this.transform.position);
		Destroy (this.gameObject);
	}

}
