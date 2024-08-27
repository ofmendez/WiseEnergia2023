using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
	public MainParagliding mainParagliding;
	private void OnTriggerEnter2D(Collider2D other) {
		mainParagliding.ReturnRing();
	}
}
