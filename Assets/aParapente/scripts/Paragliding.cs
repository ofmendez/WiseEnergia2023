using UnityEngine;

public class Paragliding : MonoBehaviour {

	public MainParagliding mainParagliding;
	public int myId;
	private void OnTriggerEnter2D(Collider2D other) {
		mainParagliding.TryMessage();
		mainParagliding.AddScore(myId);
	}
}
