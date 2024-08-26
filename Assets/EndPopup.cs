using UnityEngine;

public class EndPopup : MonoBehaviour {
	public KeyCode oneP = KeyCode.E;
	public KeyCode twoP = KeyCode.D;

	public MainParagliding mainParagliding;

	bool imEnabled = false;
	private void OnDisable() {
		imEnabled = false;
	}

	public void EndAnimation() {
		mainParagliding.Pause();
		imEnabled = true;
	}

	void Update() {
		if (imEnabled &&(Input.GetKeyDown(oneP) || Input.GetKeyDown(twoP))) {
			mainParagliding.Reset();
		}
	}
}
