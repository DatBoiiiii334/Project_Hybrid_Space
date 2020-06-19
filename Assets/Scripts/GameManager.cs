using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public SoundManager soundManager;

	public Patient currentPatient;

	private void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);

		soundManager = GetComponent<SoundManager> ();
	}

	public void SetPatient (Patient patient) {
		currentPatient = patient;
	}





}
