using UnityEngine;

public class VerticalMove : MonoBehaviour {

	// keys E to up and D to down
	public KeyCode upKey = KeyCode.E;
	public KeyCode downKey = KeyCode.D;
	public float speed ;
	
	// Update is called once per frame
	void Update () {
		// clamped in Y axis beetwen -3.5 and 3.5
		if (Input.GetKey(upKey) && transform.position.y < 3.5) {
			transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
		}
		if (Input.GetKey(downKey) && transform.position.y > -1.1) {
			transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
		}
	
	}


}
