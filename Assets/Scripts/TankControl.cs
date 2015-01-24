using UnityEngine;
using System.Collections;

public class TankControl : MonoBehaviour {

	public float speed = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Control base with left stick
		float lh = Input.GetAxis("Horizontal");
		float lv = Input.GetAxis("Vertical");
		Vector3 move = new Vector3(lh, lv, 0f);
		if (speed/10f <= move.magnitude) {
			// Rotate base
			float rot = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0f, 0f, rot - 90f);
			// Move base
			transform.Translate(move * speed, Space.World);
		}
	}
}
