using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffsetRawImage : MonoBehaviour {
	RawImage rawImage;
	public float offset = 0.001f;
	void Start() {
		rawImage = GetComponent<RawImage>();
	}

	void Update() {
	}
	void FixedUpdate() {
		rawImage.uvRect = new Rect(rawImage.uvRect.x + offset, rawImage.uvRect.y, rawImage.uvRect.width, rawImage.uvRect.height);
	}
}
