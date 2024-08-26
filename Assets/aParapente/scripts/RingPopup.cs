using UnityEngine;

public class RingPopup : MonoBehaviour {
	public MainParagliding mainParagliding;
	public void OnEnded() {
		mainParagliding.Pause();
	}
}
