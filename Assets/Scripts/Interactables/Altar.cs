using UnityEngine;

public class Altar : MonoBehaviour, IInteractable {

	[SerializeField] private ParticleSystem fireParticle;
	[SerializeField] private AudioClip burnSoundEffect;

	public void OnInteract () {
		fireParticle.Play ();
		SoundManager.instance.PlaySoundEffect (burnSoundEffect, 1f, this.transform.position);
	}

}
