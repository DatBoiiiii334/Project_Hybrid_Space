using UnityEngine;

public class Destructable : MonoBehaviour, IInteractable {

	public void OnInteract () {
		//Playsound
		//Playanimation
		//Wait for Animation finish
		Destroy (this.gameObject);
	}

}
