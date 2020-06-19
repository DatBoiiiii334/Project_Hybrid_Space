using UnityEngine;

public class Wound : MonoBehaviour, IInteractable {

	public WoundType woundType = WoundType.small;


	public void OnInteract () {	}


	public enum WoundType {
		small,
		Big,
		Clean
	};

}
