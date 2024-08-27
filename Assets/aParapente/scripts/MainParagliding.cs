using UnityEngine;
using UnityEngine.UI;

public class MainParagliding : MonoBehaviour {

	public KeyCode oneP = KeyCode.E;
	public KeyCode twoP = KeyCode.D;

	public GameObject particles;
	public GameObject scoreObj1;
	public GameObject scoreObj2;
	public GameObject nameScore1;
	public GameObject nameScore2;
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
	public TMPro.TextMeshProUGUI winnerText;
	bool twoPlayers = false;
	Vector3 initRingPosition; // -1.6 3.1
	int score1 = 0;
	int score2 = 0;
	string status = "init";
	int ring = 0;
	int ringsCrossed = 0;

	void Start() {
		initRingPosition = ringObject.transform.position;
		Reset();
	}
	string[] messageTxt = {
		"Esto fue Alto del Toro, en Dosquebradas (Risaralda), las torres y cables que ves corresponden a la línea de transmisión Armenia, a 230 kilovoltios. Las torres conviven con comunidades y ecosistemas, sin afectar la vida humana, animal, ni la flora, como lo confirma la Organización Mundial de la Salud.",
		"Santa Rosa de Cabal, en El Tambo, en donde la línea de transmisión convive sin problemas con las vías nacionales. Volar en parapente cerca de las líneas es seguro,manteniendo una distancia superior a los 50 metros de los cables y las torres, distancia que podemos garantizar mediante el uso de instrumentos de vuelo calibrados y en perfecto funcionamiento.",
		"Filandia, uno de los mayores atractivos turísticos del Quindío; esto es, gracias a la diversidad de fauna y flora, y a su conservación arquitectónica y cultural. En este lugar encontramos sitios increíbles, como el predio El Tesoro de Bremen, Aquí podemos evidenciar que el desarrollo de actividades turísticas y culturales puede coexistir con la infraestructura eléctrica.",
		"El cañón del río Barbas. Se trata de un refugio natural para diversas especies de árboles, plantas y flores, además de ser el hábitat de animales como aves, mariposas y pequeños mamíferos en el corazón del Paisaje Cultural Cafetero. 106 metros En Enlaza, identificamos las fuentes hídricas y respetamos una distancia mínima de 30 metros, con ríos o quebradas y 100 metros con nacimientos. ",
		"Eso fue Ginebra, cuna del Festival de Música Andina “Mono Núñez”.  Enlaza se preocupa por conocer el territorio y desarrollar proyectos que coexisten de manera armoniosa con las comunidades. Garantizar la seguridad energética, a través de la construcción del proyecto Refuerzo Suroccidental, contribuirá con el desarrollo turístico e industrial del Valle del Cauca.",
		"Este fue El Cerrito, territorio que se destaca por atracciones culturales como la Hacienda El Paraíso, paisajes naturales, viñedos e infraestructura turística. Turistas visitan estas montañas para disfrutar actividades gastronómicas, culturales y deportivas, como el parapente. En la búsqueda de minimizar las afectaciones a estas actividades y el impacto ambiental, en Enlaza encontramos una alternativa a nuestro trazado propuesto inicialmente, el cual permite que nuestras torres y cables se ubiquen ahora en la parte plana del municipio."
	};

	public void AddScore(int id) {
		if (id == 1) {
			score1++;
			scoreObj1.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = score1.ToString();
		} else if (id == 2) {
			score2++;
			scoreObj2.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = score2.ToString();
		} else {
		}
	}

	public void TryMessage() {
		if (ringsCrossed % 2 != 0) {
			LoadNewLevel();
		}
		particles.SetActive(true);
		ringsCrossed++;
	}

	void LoadNewLevel() {
		if (ring == messageTxt.Length - 1) {
			ShowEndPopup();
			return;
		}
		popUpMessage.SetActive(true);
		messageText.text = messageTxt[ring];
		progressBar.Launch(() => {
			EndProgress();
		});
	}

	public void ShowEndPopup() {
		if (twoPlayers)
			winnerText.text = score1 == score2 ? "Empate!" : score1 > score2 ? "Ganó: Jugador 1" : "Ganó: Jugador 2";
		else
			winnerText.text = "Ganaste!";
		endPopup.SetActive(true);
		Resume();
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
		if (ring < backgrounds.Length)
			background.sprite = backgrounds[ring];
		Time.timeScale = 1;
		player1.GetComponent<VerticalMove>().enabled = true;
		player2.GetComponent<VerticalMove>().enabled = true;
	}

	public void Play() {
		status = "playing";
		initButtons.SetActive(false);
		player1.SetActive(true);
		scoreObj1.SetActive(true);
		nameScore1.SetActive(true);
		Resume();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Reset();
		}
		if (status == "init") {
			if (Input.GetKeyDown(oneP)) {
				Play();
			}
			if (Input.GetKeyDown(twoP)) {
				twoPlayers = true;
				Play();
				scoreObj2.SetActive(true);
				nameScore2.SetActive(true);
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
		ringsCrossed = 0;
		endPopup.SetActive(false);
		popUpMessage.SetActive(false);
		initButtons.SetActive(true);
		player1.SetActive(false);
		player2.SetActive(false);
		scoreObj1.SetActive(false);
		scoreObj2.SetActive(false);
		nameScore1.SetActive(false);
		nameScore2.SetActive(false);
		ringObject.transform.position = initRingPosition;
		background.sprite = backgrounds[0];
		score1 = 0;
		score2 = 0;
		scoreObj1.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = score1.ToString();
		scoreObj2.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = score2.ToString();
		winnerText.text = "";
		twoPlayers = false;
		Pause();
	}
}
