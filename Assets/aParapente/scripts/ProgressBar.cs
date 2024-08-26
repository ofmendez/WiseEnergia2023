using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ProgressBar : MonoBehaviour {
	bool counting = false;
	public void Launch(Action callback) {
		if (counting) return;
		counting = true;
		GetComponent<Image>().fillAmount = 1;
		StartCoroutine(Countdown(callback));
	}
	IEnumerator Countdown(Action callback) {
		while (GetComponent<Image>().fillAmount > 0) {
			GetComponent<Image>().fillAmount -= 0.01f;
			// yield return new WaitForSecondsRealtime(0.05f);
			yield return new WaitForSecondsRealtime(0.01f);
		}
		callback();
		counting = false;
	}
}
