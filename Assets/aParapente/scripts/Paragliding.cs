using UnityEngine;

public class Paragliding : MonoBehaviour {

	public MainParagliding mainParagliding;
	private void OnTriggerEnter2D(Collider2D other) {
		mainParagliding.ShowMessage();
	}
}
