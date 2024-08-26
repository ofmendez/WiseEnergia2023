using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffsetComponent : MonoBehaviour {
	public float offset ;

	void FixedUpdate() {
		// Translate the object's position to the left
		transform.position = new Vector3(transform.position.x - offset, transform.position.y, transform.position.z);
	}
}
