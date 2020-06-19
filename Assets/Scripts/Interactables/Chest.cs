using UnityEngine;

public class Chest : MonoBehaviour, IInteractable {

	[SerializeField] private GameObject itemToBeUnlocked;

	public void OnInteract () {
		itemToBeUnlocked.SetActive (true);
	}

}
