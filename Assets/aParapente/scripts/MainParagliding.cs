using UnityEngine;
using UnityEngine.UI;

public class MainParagliding : MonoBehaviour {

	public KeyCode oneP = KeyCode.E;
	public KeyCode twoP = KeyCode.D;
	public GameObject player1;
	public GameObject player2;
	public GameObject initButtons;

	public GameObject popUpMessage;
	public TMPro.TextMeshProUGUI messageText;
	public ProgressBar progressBar;
	public GameObject ringObject;
	public GameObject endPopup;
	public Image background;
	public Sprite[] backgrounds;
	Vector3 initRingPosition; // -1.6 3.1

	string status = "init";
	int ring = 0;

	void Start() {
		initRingPosition = ringObject.transform.position;
		Pause();
	}
	string[] messageTxt = {
		"Message 1 lorem ipsum dolor sit amet",
		"Message 2 lorem ipsum dolor sit amet",
		"Message 3 lorem ipsum dolor sit amet",
		"Message 4 lorem ipsum dolor sit amet",
		"Message 5 lorem ipsum dolor sit amet",
		"Message 6 lorem ipsum dolor sit amet"
	};

	public void ShowMessage() {
		if (ring == messageTxt.Length) {
			endPopup.SetActive(true);
			Resume();
			return;
		}
		popUpMessage.SetActive(true);
		messageText.text = messageTxt[ring];
		background.sprite = backgrounds[ring];
		progressBar.Launch(() => {
			EndProgress();
		});
	}

	public void EndProgress() {
		popUpMessage.SetActive(false);
		ring++;
		ReturnRing();
		Resume();
	}

	public void Pause() {
		Time.timeScale = 0.0001f;
		player1.GetComponent<VerticalMove>().enabled = false;
		player2.GetComponent<VerticalMove>().enabled = false;
	}

	public void Resume() {
		Time.timeScale = 1;
		player1.GetComponent<VerticalMove>().enabled = true;
		player2.GetComponent<VerticalMove>().enabled = true;
	}

	public void Play() {
		status = "playing";
		initButtons.SetActive(false);
		player1.SetActive(true);
		Resume();
	}

	void Update() {
		if (status == "init") {
			if (Input.GetKeyDown(oneP)) {
				Play();
			}
			if (Input.GetKeyDown(twoP)) {
				Play();
				player2.SetActive(true);
			}
		}
	}

	public void ReturnRing() {
		float yPosition = Random.Range(-1.6f, 3.1f);
		ringObject.transform.position = new Vector3(initRingPosition.x, yPosition, initRingPosition.z);
	}
	public void Reset() {
		status = "init";
		ring = 0;
		endPopup.SetActive(false);
		initButtons.SetActive(true);
		player1.SetActive(false);
		player2.SetActive(false);
		ringObject.transform.position = initRingPosition;
		background.sprite = backgrounds[0];
		Pause();
	}
}
